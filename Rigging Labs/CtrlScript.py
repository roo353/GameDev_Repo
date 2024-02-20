import maya.cmds as cmds

def create_control_joint(joint_name):
    # Create a NURBS curve (control)
    control_curve = cmds.circle(name=f"{joint_name}_CTRL", normal=(1, 0, 0))[0]
    
    # Create an empty group (parent group)
    parent_group = cmds.group(empty=True, name=f"{joint_name}_GRP")
    
    # Get joint position
    joint_position = cmds.xform(joint_name, query=True, translation=True, worldSpace=True)
    
    # Move control curve and parent group to joint's position
    cmds.move(joint_position[0], joint_position[1], joint_position[2], control_curve, absolute=True)
    cmds.move(joint_position[0], joint_position[1], joint_position[2], parent_group, absolute=True)
    
    # Parent the control under the parent group
    cmds.parent(control_curve, parent_group)
    
    # Rename control and parent group
    cmds.rename(control_curve, f"{joint_name}_CTRL")
    cmds.rename(parent_group, f"{joint_name}_GRP")

    # List of selected joints
    selected_joints = cmds.ls(selection=True, type='joint')

    # Create control joint for each selected joint
    for joint in selected_joints:
        create_control_joint(joint)
