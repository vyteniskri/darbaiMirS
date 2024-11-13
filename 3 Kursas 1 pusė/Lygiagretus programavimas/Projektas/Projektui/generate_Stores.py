import random
import numpy as np
import json

CITY_SIZE_X = (-10, 10)
CITY_SIZE_Y = (-10, 10)
exsisting_stores_Count = np.random.randint(120, 121)
new_stores_Count = np.random.randint(120, 121)

def generate_stores_loc(num_stores, city_size_x, city_size_y):
    return [(random.uniform(city_size_x[0], city_size_x[1]), random.uniform(city_size_y[0], city_size_y[1])) for _ in range(num_stores)]

if __name__ == "__main__":
    print(f"Generating {exsisting_stores_Count} exsisting stores...")
    exsisting_stores = generate_stores_loc(exsisting_stores_Count, CITY_SIZE_X, CITY_SIZE_Y)
    print(f"Generating {new_stores_Count} new stores...")
    new_stores = generate_stores_loc(new_stores_Count, CITY_SIZE_X, CITY_SIZE_Y)

    data = {
        "city_size_x": CITY_SIZE_X,
        "city_size_y": CITY_SIZE_Y,
        "exsisting_stores": exsisting_stores,
        "new_stores": new_stores

    }

    filename = f"exsisting{exsisting_stores_Count}_new{new_stores_Count}.json"

    print(f"Saving as {filename}")

    with open("Data/"+ filename, 'w') as f:
        json.dump(data, f, indent=4)