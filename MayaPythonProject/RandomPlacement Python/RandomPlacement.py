import maya.cmds as cmds
import random # Allows for the use of the random variable

def duplicate_and_disperse_objects(num_duplicates, min_x, max_x, min_y, max_y, min_z, max_z):
    # Gets the selected objects
    selected_objects = cmds.ls(selection=True, dag=True, long=True)

    if not selected_objects:
        cmds.warning("No objects selected. Please select objects to duplicate.")
        return

    # Duplicates selected objects
    duplicated_objects = []
    for _ in range(num_duplicates):
        duplicated_objects.extend(cmds.duplicate(selected_objects, returnRootsOnly=True))

    # Randomly disperses duplicated objects
    for obj in duplicated_objects:
        # Generate random positions
        random_x = random.uniform(min_x, max_x)
        random_y = random.uniform(min_y, max_y)
        random_z = random.uniform(min_z, max_z)

        # Sets the new position for the duplicated object
        cmds.move(random_x, random_y, random_z, obj, absolute=True)

    print(f"{num_duplicates} objects duplicated and dispersed.")

# Example
duplicate_and_disperse_objects(num_duplicates=5, min_x=-10, max_x=10, min_y=0, max_y=20, min_z=-5, max_z=5)
