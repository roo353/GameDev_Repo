import maya.cmds as cmds


def change_shape_override_color():
    """
    Change the override color of the shape node for selected object(s).
    """
    try:
        new_color = int(input("Enter the new color index (0-31): "))
    except ValueError:
        print("Invalid input. Please enter a valid color index (0-31).")
        return

    if new_color < 0 or new_color > 31:
        print("Invalid color index. Please enter a value between 0 and 31.")
        return

    selected_objects = cmds.ls(selection=True)  # Get currently selected objects
    for obj in selected_objects:
        shapes = cmds.listRelatives(obj, shapes=True, fullPath=True) or []
        for shape in shapes:
            cmds.setAttr(shape + '.overrideEnabled', 1)
            cmds.setAttr(shape + '.overrideColor', new_color)


# Example usage:
change_shape_override_color()
