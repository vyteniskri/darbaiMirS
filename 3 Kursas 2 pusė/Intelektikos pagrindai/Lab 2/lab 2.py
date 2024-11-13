import time
import pandas as pd
from sklearn.tree import DecisionTreeClassifier, export_graphviz
import graphviz
from sklearn.metrics import accuracy_score, confusion_matrix
from sklearn.utils import resample
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import GridSearchCV

def test_different_depth(max_depth, X_train, X_test, y_train, y_test):
    start_time = time.time()
    tree_model = DecisionTreeClassifier(max_depth=max_depth, criterion='gini')
    tree_model.fit(X_train, y_train)
    end_time = time.time()
    training_time = end_time - start_time
    y_pred = tree_model.predict(X_test)
    accuracy = accuracy_score(y_test, y_pred)
    return training_time, accuracy


max_depths = [2, 4, 8, 16, 32, 64, 128, 256]
results = []

file_path_learn = 'Apmokymo_aibe.xlsx'
df = pd.read_excel(file_path_learn)

file_path_test = 'Testavimo_aibe.xlsx'
df2 = pd.read_excel(file_path_test)  

# Define features and target
features = ['wait', 'travel']
target = 'mode'

X_test = df2[features]
Y_test = df2[target]

# Prepare the data
X_train = df[features]
Y_train = df[target]

# Build the decision tree
tree_model = DecisionTreeClassifier(criterion='gini')
tree_model.fit(X_train, Y_train)

# Make predictions on the testing data
y_pred = tree_model.predict(X_test)

# Calculate prediction accuracy score = number of corect predictions/ total number of predictions
accuracy = accuracy_score(Y_test, y_pred)
print("Prognozavimo tikslumas:", accuracy)

# Calculate confusion matrix 
conf_matrix = confusion_matrix(Y_test, y_pred)
print("Sumaišymo matrica:")
print(conf_matrix)

# Visualize the decision tree
dot_data = export_graphviz(tree_model, out_file=None,
                           feature_names=features,
                           class_names=tree_model.classes_,
                           filled=True, rounded=True,
                           special_characters=True)

graph = graphviz.Source(dot_data)
graph.render("decision_tree")  # Save the decision tree visualization as a PDF file
graph.view()  # Show the decision tree visualization in the default PDF viewer

for depth in max_depths:
    training_time, accuracy = test_different_depth(depth, X_train, X_test, Y_train, Y_test)
    results.append((depth, training_time, accuracy))

print("Rezultatai:")
print("Gylis\tFormavimo trukmė (s)\tTikslumas")
for result in results:
    print(f"{result[0]}\t{result[1]}\t\t{result[2]}")



random_forest = RandomForestClassifier(n_estimators=5)
random_forest.fit(X_train, Y_train)
# Set feature names for each decision tree
y_pred = random_forest.predict(X_test) #Is visu medziu paimamas daugiau vote sirinkes spejimas
accuracy = accuracy_score(Y_test, y_pred)
print("Prognozavimo tikslumas atsitiktiniui miškui:", accuracy)

max_accuracy = 0
best_max_depth = None
for i, (tree, samples) in enumerate(zip(random_forest.estimators_, random_forest.estimators_samples_)):
    bootstraped_data_X = X_train.iloc[samples]
    bootstraped_data_Y = Y_train.iloc[samples]
    tree.fit(bootstraped_data_X, bootstraped_data_Y)
    y_pred = tree.predict(X_test)
    accuracy = accuracy_score(Y_test, y_pred)
    depth = tree.tree_.max_depth

    print(f"Sprendimų medis {i} Prognozavimo tikslumas: {accuracy}, Gylis: {depth}")
    if accuracy > max_accuracy:
        max_accuracy = accuracy
        best_max_depth = depth

print(f"Geriausias gylis: {best_max_depth} su prognozavimo tikslumu: {max_accuracy}")    

param_grid = {
    'n_estimators': [3, 4, 5, 6, 7, 8, 9]
}

random_forest = RandomForestClassifier()
grid_search = GridSearchCV(random_forest, param_grid, cv=5, scoring='accuracy')
grid_search.fit(X_train, Y_train)

mean_test_scores = grid_search.cv_results_['mean_test_score']
n_estimators_values = [params['n_estimators'] for params in grid_search.cv_results_['params']]

for n_estimators, accuracy in zip(n_estimators_values, mean_test_scores):
    print(f"Medžių kiekis: {n_estimators}, Tikslumas: {accuracy}")
    
best_params = grid_search.best_params_
best_accuracy = grid_search.best_score_

print("Geriausias medžių kiekis:", best_params)
print("Geriausias tikslumas:", best_accuracy)