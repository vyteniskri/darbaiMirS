
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.metrics import silhouette_score
import time
# Self-Organizing Map (SOM) class
class SOM:
    def __init__(self, m, n, dim, num_iterations=100, alpha=0.5):
        self.m = m  # Grid height
        self.n = n  # Grid width
        self.dim = dim  # Dimensionality of input data
        self.num_iterations = num_iterations
        self.alpha = alpha  # Initial learning rate
        self.weights = np.random.rand(m, n, dim)  # Initialize weights
 
    def _neighborhood_function(self, distance, radius):
        return np.exp(-distance**2 / (2 * radius**2))
 
    def _update_weights(self, x, bmu_idx, iteration): # Klasteriu svoriai optimizuojami
        learning_rate = self.alpha * (1 - iteration / self.num_iterations) # a
       
        radius = np.exp(-iteration / self.num_iterations) # sigma
        for i in range(self.m):
            for j in range(self.n):
                neuron = np.array([i, j])
                bmu = np.array(bmu_idx)
                dist = np.linalg.norm(neuron - bmu)
                if dist <= radius:
                    influence = self._neighborhood_function(dist, radius) # h
                    self.weights[i, j, :] += influence * learning_rate * (x - self.weights[i, j, :]) #Pakeiciamas esamas ir gretimi svoriai
 
    def train(self, data):
        for iteration in range(self.num_iterations):
            for x in data:
                distances = np.linalg.norm(self.weights - x, axis=-1)
                bmu_idx = np.unravel_index(np.argmin(distances), (self.m, self.n)) # Geriausias esamas klasteriu svoris
                self._update_weights(x, bmu_idx, iteration)
 
    def map_data(self, data):
        mapped_data = []
        for x in data:
            distances = np.linalg.norm(self.weights - x, axis=-1)
            bmu_idx = np.unravel_index(np.argmin(distances), (self.m, self.n))
            mapped_data.append(bmu_idx)
        return mapped_data
 
    def get_centroids(self):
        centroids = self.weights.reshape(-1, self.weights.shape[-1])
        return centroids
    
# Load the dataset
data = pd.read_csv("Normalizuoti_duomenys.csv")
data = data.head(1000)
 
# Select the attributes for clustering
attributes = ['wait', 'vcost', 'travel', 'gcost']
 


# Loop through each pair of attributes
for i in range(len(attributes)):
    for j in range(i + 1, len(attributes)):
        X = data[[attributes[3], attributes[0]]].values
 
        # Store inertia and silhouette scores for different grid sizes
        inertias = []
        silhouette_scores = []
        inertia_changes = []
 
        for grid_size in range(1, 11):  # Klasteriu skaicius
            som = SOM(m=1, n=grid_size, dim=2, num_iterations=1000, alpha=0.5)
            start_time = time.time()  # Record start time
            som.train(X)
            end_time = time.time()  # Record end time
            training_time = end_time - start_time
            print(f"Training time: {training_time}")
            mapped_data = som.map_data(X)
            
            # Calculate inertia
            inertia = sum(np.min(np.linalg.norm(som.weights - x, axis=-1))**2 for x in X) #Sum of best mathcing units
            inertias.append(inertia)
            
            # Calculate silhouette score if there are at least 2 clusters
            if grid_size > 1:
                labels = [x[0] * grid_size + x[1] for x in mapped_data]
                silhouette = silhouette_score(X, labels) # how similar an object is to its own cluster compared to other clusters.
                silhouette_scores.append(silhouette)
                print(f"Inertia for {grid_size} clusters: {inertia}")
                print(f"Silhouette Score for {grid_size} clusters: {silhouette}")
            else:
                silhouette_scores.append(-1)  # Placeholder for 1 cluster case
 
            # Calculate inertia change
            if grid_size > 1:
                inertia_change = (inertias[-2] - inertias[-1]) / inertias[-2]
                inertia_changes.append(inertia_change)
                if inertia_change < 0.02:  # Stopping criterion
                    print(f"Stopping at grid size {grid_size} due to small inertia change: {inertia_change:.4f}")
                    break
            else:
                inertia_changes.append(None)
 
        # Plot inertia vs number of clusters
        plt.figure(figsize=(10, 6))
        plt.plot(range(1, len(inertias) + 1), inertias, marker='o', linestyle='--')
        plt.xlabel('Number of clusters (Grid size)')
        plt.ylabel('Inertia')
        plt.title('Inertia and Number of Clusters')
        plt.grid(True)
        plt.show()
 
        # Plot silhouette score vs number of clusters, skipping 1 cluster case
        plt.figure(figsize=(10, 6))
        plt.plot(range(2, len(silhouette_scores) + 1), silhouette_scores[1:], marker='o', linestyle='--')
        plt.xlabel('Number of clusters')
        plt.ylabel('Silhouette Score')
        plt.title('Silhouette Score and Number of Clusters')
        plt.grid(True)
        plt.show()
 
        # Plot inertia change vs number of clusters
        plt.figure(figsize=(10, 6))
        plt.plot(range(2, len(inertia_changes) + 1), inertia_changes[1:], marker='o', linestyle='--')
        plt.xlabel('Number of clusters')
        plt.ylabel('Inertia Change')
        plt.title('Inertia Change and Number of Clusters')
        plt.grid(True)
        plt.show()
 
        # Plot the SOM clusters for the best grid size (highest silhouette score)
        best_grid_size = np.argmax(silhouette_scores[1:]) + 2
        som = SOM(m=1, n=best_grid_size, dim=2, num_iterations=1000, alpha=0.5)
        som.train(X)
        mapped_data = som.map_data(X)
        centroids = som.get_centroids()
        labels = [x[0] * best_grid_size + x[1] for x in mapped_data]
        best_silhouette = silhouette_score(X, labels)
        
        plt.figure(figsize=(10, 6))
        plt.scatter(X[:, 0], X[:, 1], c=labels, cmap='viridis', s=50, alpha=0.5)
        plt.scatter(centroids[:, 0], centroids[:, 1], marker='x', c='red', s=200, label='Centroids')
        plt.title(f'SOM Clustering: {attributes[1]} vs {attributes[3]} (Best claster number:  {best_grid_size})')
        plt.xlabel(attributes[1])
        plt.ylabel(attributes[3])
        plt.legend()
        plt.grid(True)
        plt.text(0.05, 0.95, f'Silhouette Score: {best_silhouette:.2f}', transform=plt.gca().transAxes, fontsize=12, verticalalignment='top')
        plt.show()

