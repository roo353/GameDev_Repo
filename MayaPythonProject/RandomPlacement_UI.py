import maya.cmds as cmds
import random

def duplicate_and_disperse_objects(num_duplicates, min_x, max_x, min_y, max_y, min_z, max_z):
    selected_objects = cmds.ls(selection=True, dag=True, long=True)

    if not selected_objects:
        cmds.warning("No objects selected. Please select objects to duplicate.")
        return

    duplicated_objects = []
    for _ in range(num_duplicates):
        duplicated_objects.extend(cmds.duplicate(selected_objects, returnRootsOnly=True))

    for obj in duplicated_objects:
        random_x = random.uniform(min_x, max_x)
        random_y = random.uniform(min_y, max_y)
        random_z = random.uniform(min_z, max_z)

        cmds.move(random_x, random_y, random_z, obj, absolute=True)

    print(f"{num_duplicates} objects duplicated and dispersed.")

def createUI():
    if cmds.window("duplicateAndDisperseUI", exists=True):
        cmds.deleteUI("duplicateAndDisperseUI", window=True)

    window = cmds.window("duplicateAndDisperseUI", title="Duplicate and Disperse UI", widthHeight=(300, 200))
    layout = cmds.columnLayout(adjustableColumn=True)

    cmds.text(label="Select objects and set parameters for duplication and dispersion.")

    cmds.intSliderGrp(label="Number of Duplicates", field=True, minValue=1, maxValue=10, fieldMinValue=1, fieldMaxValue=100, value=5, step=1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Min X", field=True, minValue=-50, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=-10, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Max X", field=True, minValue=-50, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=10, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Min Y", field=True, minValue=0, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=0, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Max Y", field=True, minValue=0, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=20, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Min Z", field=True, minValue=-50, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=-5, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))
    cmds.floatSliderGrp(label="Max Z", field=True, minValue=-50, maxValue=50, fieldMinValue=-100, fieldMaxValue=100, value=5, step=0.1, adjustableColumn=True, columnAlign=(1, 'right'))

    cmds.button(label="Duplicate and Disperse", command=lambda x: execute_duplicate_and_disperse())

    def execute_duplicate_and_disperse():
        num_duplicates = cmds.intSliderGrp(q=True, value=True)
        min_x = cmds.floatSliderGrp("Min X", q=True, value=True)
        max_x = cmds.floatSliderGrp("Max X", q=True, value=True)
        min_y = cmds.floatSliderGrp("Min Y", q=True, value=True)
        max_y = cmds.floatSliderGrp("Max Y", q=True, value=True)
        min_z = cmds.floatSliderGrp("Min Z", q=True, value=True)
        max_z = cmds.floatSliderGrp("Max Z", q=True, value=True)

        duplicate_and_disperse_objects(num_duplicates, min_x, max_x, min_y, max_y, min_z, max_z)

    cmds.showWindow(window)

# Call the UI creation function
createUI()
