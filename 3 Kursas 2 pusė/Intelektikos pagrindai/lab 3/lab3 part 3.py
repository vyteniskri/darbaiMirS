import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from sklearn.model_selection import KFold
from sklearn.metrics import mean_squared_error

file_path_learn = 'Normalizuoti_duomenys.csv'
df = pd.read_csv(file_path_learn)

# Define mapping dictionary
mode_mapping = {'air': 1, 'car': 2, 'train': 3, 'bus': 4}

# Replace categorical values with numerical values
df['mode'] = df['mode'].map(mode_mapping)

# Define features and target
features = ['wait', 'travel']
target = 'mode'


# Train data
X = df[features]
Y = df[target]

# 6
# # Create a colormap for different modes
# colors = {1: 'r', 2: 'g', 3: 'b', 4: 'y'}

# # Create a color list based on 'mode' attribute
# color_list = [colors[mode] for mode in Y]

# # Plotting
# fig = plt.figure()
# ax = fig.add_subplot(111, projection='3d')

# x = X['wait']
# y = X['travel']
# z = Y

# ax.scatter(x, y, z, c=color_list, marker='o')

# ax.set_xlabel('wait')
# ax.set_ylabel('travel')
# ax.set_zlabel('Mode')
# plt.title('Įvesties ir išvesties duomenys')

# plt.show()



# Activation Function Modification Relu
def relu(x, deriv=False):
    if deriv:
        return np.where(x > 0, 1, 0)
    return np.maximum(0, x)


# Sigmoid activation function and its derivative
def nonlin(x, deriv=False):
    if deriv:
        return x * (1 - x)
    return 1 / (1 + np.exp(-x))
# Define the number of folds
num_folds = 10

# Initialize KFold with 10 folds
kf = KFold(n_splits=num_folds)

# Initialize an empty list to store MSE values for each fold
mse_scores = []
learning_rate = 0.001

# Iterate over each fold
for train_index, test_index in kf.split(X):
    # Split data into train and test sets for this fold
    X_train_fold, X_test_fold = X.iloc[train_index], X.iloc[test_index]
    y_train_fold, y_test_fold = Y.iloc[train_index], Y.iloc[test_index]
    
    # Define input and output data for this fold
    X_fold = X_train_fold.values
    y_fold = y_train_fold.values.reshape(-1, 1)
    
    # Initialize weights randomly with mean 0, 2 ivestys
    syn0_fold = np.array([[0.5], [0.5]])

    # Training loop for this fold
    for iter in range(10000):
        # Forward propagation
        l0_fold = X_fold
        l1_fold = relu(np.dot(l0_fold, syn0_fold))

        # Error calculation
        l1_error_fold = y_fold - l1_fold

        # Error weighted delta calculation
        l1_delta_fold = learning_rate * l1_error_fold * relu(l1_fold, True)

        # Update weights
        syn0_fold += np.dot(l0_fold.T, l1_delta_fold)
    
    # Make predictions on the test set for this fold
    l0_test_fold = X_test_fold.values
    l1_test_fold = relu(np.dot(l0_test_fold, syn0_fold))
    
    # Calculate MSE for this fold
    mse_fold = mean_squared_error(y_test_fold, l1_test_fold)
    
    # Append MSE to the list of scores
    mse_scores.append(mse_fold)

print(mse_scores)
# Calculate the average MSE over all folds
avg_mse = np.mean(mse_scores)

# Print the average MSE
print("Average Mean Squared Error (MSE) across 10 folds:", avg_mse)