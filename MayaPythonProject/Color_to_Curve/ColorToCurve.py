import maya.cmds as cmds

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
                # change the color of the material to red
                cmds.setAttr(shaders[0] + ".color", 1, 0, 0, type="double3")



