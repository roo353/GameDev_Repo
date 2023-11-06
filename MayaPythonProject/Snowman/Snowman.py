import maya.cmds as cmds

# Create snowman body
body = cmds.polySphere(r=5, sx=20, sy=20)
cmds.move(0, 7.5, 0, body)

# Create snowman head
head = cmds.polySphere(r=3.5, sx=20, sy=20)
cmds.move(0, 14.5, 0, head)

# Create eyes
left_eye = cmds.polySphere(r=0.2, sx=20, sy=20)
right_eye = cmds.polySphere(r=0.2, sx=20, sy=20)
cmds.move(-1, 15.5, 3.3, left_eye)
cmds.move(1, 15.5, 3.3, right_eye)
# Scale the eyes to make them more flat
cmds.scale(1.5, 1.5, 0.5, left_eye)
cmds.scale(1.5, 1.5, 0.5, right_eye)

# Create nose
nose = cmds.polyCone(r=0.5, h=2, sx=20)
cmds.move(0, 14.7, 4, nose)
cmds.xform(nose, ro=(90, 0, 0))  # Rotate the nose

# Create buttons
buttons = []
for i in range(4):
    button = cmds.polySphere(r=0.3, sx=20, sy=20)
    cmds.move(0, 9 - i, 5, button)
    buttons.append(button)

# Create hat
hat_base = cmds.polyCylinder(r=4.5, h=1, sx=20)
cmds.move(0, 17, 0, hat_base)
hat_top = cmds.polyCylinder(r=3, h=5, sx=20)
cmds.move(0, 19, 0, hat_top)
