import maya.cmds as cmds

def changeColor(color):
    selections = cmds.ls(sl=True)

    for sel in selections:
        # get shape of selection:
        sel_shape = cmds.ls(sel, dag=True, shapes=True)

        # check if there is a shape
        if sel_shape:
            # get shading groups from shape:
            shadingGrps = cmds.listConnections(sel_shape, type='shadingEngine')

            # check if there is a shading group
            if shadingGrps:
                # get the shaders:
                shaders = cmds.ls(cmds.listConnections(shadingGrps), materials=True)

                # check if there is a shader
                if shaders:
                    # change the color of the material
                    cmds.setAttr(shaders[0] + ".color", *color, type="double3")

def createUI():
    if cmds.window("changeColorUI", exists=True):
        cmds.deleteUI("changeColorUI", window=True)

    window = cmds.window("changeColorUI", title="Change Color UI", widthHeight=(300, 100))
    layout = cmds.columnLayout(adjustableColumn=True)

    cmds.text(label="Select objects and choose a color to apply.")
    
    color_slider = cmds.colorSliderGrp(label="Color", hsv=(0, 1, 1), changeCommand=lambda x: changeColor(cmds.colorSliderGrp(color_slider, query=True, rgb=True)))

    cmds.button(label="Change Color", command=lambda x: changeColor(cmds.colorSliderGrp(color_slider, query=True, rgb=True)))

    cmds.showWindow(window)

# Call the UI creation function
createUI()
