# NXOpen API Detailed Reference

Extracted from official NXOpen XML documentation.

## Session

Represents the NX session.

### Methods
- **UndoMarkData**: Constructor for the UndoMarkData struct.
- **GetSession**: Gets the singleton for <see cref="T:NXOpen.Session"> NXOpen.Session </see>
- **SetUndoMark**: Creates an undo mark
- **UndoToLastVisibleMark**: Undo to last visible mark.
- **Redo**: Redo the last undo if possible.
- **UndoToMark**: Undo to the specified mark
- **UndoToMarkWithStatus**: Undo to the specified mark and output status to status bar.
- **DeleteUndoMark**: Deletes an undo mark.
- **DeleteUndoMarksUpToMark**: Deletes all undo marks up to and including the specified mark.
- **DeleteAllUndoMarks**: Deletes all undo marks

### Properties
- **AfuManager**: Returns the <see cref="T:NXOpen.CAE.AfuManager"> NXOpen.CAE.AfuManager </see> belonging to this session
- **DexManager**: Returns the <see cref="T:NXOpen.DexManager"> NXOpen.DexManager </see> belonging to this session
- **PvtransManager**: Returns the <see cref="T:NXOpen.PvtransManager"> NXOpen.PvtransManager </see> belonging to this session
- **FTKManager**: Returns the <see cref="T:NXOpen.CAE.FTK.FTKManager"> NXOpen.CAE.FTK.FTKManager </see> belonging to this session
- **Post**: Returns the <see cref="T:NXOpen.CAE.Post"> NXOpen.CAE.Post </see> belonging to this session
- **ResultManager**: Returns the <see cref="T:NXOpen.CAE.ResultManager"> NXOpen.CAE.ResultManager </see> belonging to this session
- **CaeSession**: Returns the <see cref="T:NXOpen.CAE.CaeSession"> NXOpen.CAE.CaeSession </see> belonging to this session
- **UpdateManager**: Returns the <see cref="T:NXOpen.Update"> NXOpen.Update </see> belonging to this session
- **Parts**: Returns the <see cref="T:NXOpen.PartCollection"> NXOpen.PartCollection </see> belonging to this session
- **WeldCustomManager**: Returns the <see cref="T:NXOpen.Weld.CustomManager"> NXOpen.Weld.CustomManager </see> belonging to this session

## Part

Represents an NX part of type .prt.

### Methods
- **PartFamilyAttributeData**: Constructor for the PartFamilyAttributeData struct.
- **FeatureUpdateStatus**: Constructor for the FeatureUpdateStatus struct.
- **GetUpdateStatusReport**: Get feature update status report
- **ResetTimestampToLatestFeature**: Sets the timestamp for the part to the timestamp of the latest feature in the part.
- **CreateObjectList**: Creates an empty list that can be populated with any NXObject
- **CreateEmptyExpressionSectionSet**: Creates an empty ExpressionSectionSet item
- **CreateEmptyExpressionCollectorSet**: Creates an empty ExpressionCollectorSet item
- **CreateCamSetup**: Creates CAM setup
- **DeleteCamSetup**: Delete CAM setup
- **CreateInspectionSetup**: Creates CMM Inspection setup

### Properties
- **Bodies**: Returns the BodyCollection instance belonging to this part
- **CutViews**: Returns the CutViewCollection instance belonging to this part
- **Dimensions**: Returns the DimensionCollection instance belonging to this part
- **DraftingViews**: Returns the DraftingViewCollection instance belonging to this part
- **DrawingSheets**: Returns the DrawingSheetCollection instance belonging to this part
- **DraftingDrawingSheets**: Returns the DraftingDrawingSheetCollection instance belonging to this part
- **Notes**: Returns a collection of notes
- **Labels**: Returns a collection of labels
- **Gdts**: Returns a collection of GDTs
- **Markers**: Return a collection of Markers

## Body

Represents a Body

### Methods
- **GetFeatures**: Returns the features used to construct the body
- **GetFaces**: Returns the faces in the body
- **GetEdges**: Returns the edges in the body
- **RemoveMergedRibImprintedEdges**: Removes imprinted edges created by the merged rib rule.
- **GetFacetedBody**: Returns a lightweight JT <see cref="T:NXOpen.Facet.FacetedBody"> NXOpen.Facet.FacetedBody </see> associated with this body and checks whether it is out of date.
- **SweepabilityCheck**: Sweepability check
- **GetNumberOfFacets**: Returns the number of facets on all the faces of this convergent body.
- **GetNumberOfVertices**: Returns the number of vertices on all the faces of this convergent body.
- **GetNextFacet**: Returns a facet next to given facet on convergent body.
- **GetFirstFacetOnBody**: Returns first facet on a convergent body.

### Properties
- **Density**: Returns or sets the solid density of the body.
- **IsConvergentBody**: Returns true if the body is a convergent body.
- **IsSheetBody**: Returns true if the body is a sheet body
- **IsSolidBody**: Returns true if the body is a solid body

## Face

Represents a face

### Methods
- **GetEdges**: Returns the edges in the face
- **GetUnsortedEdges**: Returns the edges in the face
- **GetBody**: Returns the body containing this face
- **GetNumberOfFacets**: Returns the number of facets on a convergent face.
- **GetNumberOfVertices**: Returns the number of vertices on this convergent face.
- **GetNextFacet**: Returns a facet next to the input facet on a convergent face.
- **GetFirstFacetOnFace**: Returns first facet on convergent face.
- **DestroyOwnedFacets**: Destroys all <see cref="T:NXOpen.IFacet"> IFacet </see> objects owned by this face.
- **GetChamferData**: Check whether a face is chamfer and return the chamfer data for chamfer face
- **GetBlendData**: Identify blend face and get it's radius

### Properties
- **SolidFaceType**: Returns the Parasolid type of the face

## Edge

Represents an edge

### Methods
- **GetFaces**: Returns the faces connected to the edge.
- **GetUnsortedFaces**: Returns the faces connected to the edge.
- **GetVertices**: Returns the vertices of the edge.
- **GetBody**: Returns the body containing this edge
- **GetDraftingCurveInfo**: Creates new DraftingCurveInfo object
- **IsDraftingCurve**: Checks if an object is a Drafting Curve
- **GetLength**: Returns the length of the object
- **GetLocations**: Finds the locations associated with this curve

### Properties
- **SolidEdgeType**: Returns the solid type of the edge
- **IsReference**: Returns the reference state of a curve

## Features.ExtrudeBuilder

Represents a extrude feature builder.

### Methods
- **SetToleranceValues**: SET all the tolerances at once
- **AllowSelfIntersectingSection**: SET option for supporting self-intersecting section

### Properties
- **AngularTolerance**: Returns or sets the angle tolerance
- **BooleanOperation**: Returns the extrude boolean operation
- **ChainingTolerance**: Returns or sets the chaining tolerance
- **Direction**: Returns or sets the extrude direction
- **DistanceTolerance**: Returns or sets the distance tolerance
- **Draft**: Returns the extrude draft operation
- **FeatureOptions**: Returns the feature options
- **Limits**: Returns the extrude limits
- **Offset**: Returns the extrude Offset operation
- **PlanarTolerance**: Returns or sets the planar tolerance

## Features.RevolveBuilder

Represents a revolve builder.

### Properties
- **Axis**: Returns or sets the revolve axis
- **BooleanOperation**: Returns the revolve boolean
- **FeatureOptions**: Returns the feature options
- **Limits**: Returns the limit data
- **Offset**: Returns the revolve offset
- **Section**: Returns or sets the section
- **SmartVolumeProfile**: Returns the smart volume profile
- **Tolerance**: Returns or sets the revolve tolerance

## Features.BooleanBuilder

Represents a boolean feature builder.

### Properties
- **BooleanRegionSelect**: Returns the boolean region select object
- **ConvertToSew**: Returns or sets the convert to sew flag
- **CopyTargets**: Returns or sets the copy targets flag
- **CopyTools**: Returns or sets the copy tools flag
- **Operation**: Returns or sets the boolean operation
- **RemoveTargetVoids**: Returns or sets the remove target voids flag for Transfer Voids
- **RetainTarget**: Returns or sets the retain target flag
- **RetainTool**: Returns or sets the retain tool flag
- **Target**: Returns or sets the target body
- **TargetBodyCollector**: Returns or sets the target body collector for the boolean operation

## Features.EdgeBlendBuilder

Represents a Edge Blend builder.

### Methods
- **AddChainset**: Add an edge blend chainset to the edge blend
- **AddChainset**: Add an edge blend chainset to the edge blend
- **GetChainsetIndex**: Get the index of edge blend chainset given the collector
- **GetNumberOfValidChainsets**: Get the number of valid chainsets
- **GetChainset**: Get collector and radius for an edge blend chainset given the index of the chainset
- **GetChainsetAndSectionValue**: Get collector, radius and section types for an edge blend chainset given the index of the chainset
- **GetChainsetAndStatus**: Get collector, radius and validity status for an edge blend chainset given the index of the chainset
- **RemoveChainset**: Delete an edge blend chainset from the edge blend.
- **RemoveChainsetByCollector**: Delete an edge blend chainset from the edge blend.
- **GetSetbackData**: Get an edge blend setback data for the index provided

### Properties
- **AllInstancesOption**: Returns or sets the blend all instances option
- **BlendFaceContinuity**: Returns or sets the Blend Face Continuity option
- **BlendOrder**: Returns or sets the order of blending for edge blend
- **CliffEdges**: Returns or sets the forced cliff edges for edge blend
- **ConvexConcaveY**: Returns or sets the Special blend at convex / concave Y option
- **LimitFailingAreas**: Returns or sets the Limit Failing Areas option
- **LimitsListData**: Returns the limits list
- **MoveSharpEdge**: Returns or sets the Maintain blend and move sharp edges option
- **NonCliffEdges**: Returns or sets the prohibited cliff edges for edge blend
- **OverlapOption**: Returns or sets the overlap resolution for edge blend

## Features.ChamferBuilder

Represents the chamfer builder data.

### Methods
- **CreatePreview**: Creates the chamfer preview body

### Properties
- **AllInstances**: Returns or sets the chamfer all instance status
- **Angle**: Returns or sets the chamfer angle (expression).
- **AngleExp**: Returns the angle expression object of chamfer.
- **FirstOffset**: Returns or sets the first offset distance (expression).
- **FirstOffsetExp**: Returns the first offset expression object of chamfer.
- **Method**: Returns or sets the offset method.
- **Option**: Returns or sets the chamfer parameter option.
- **ReverseOffsets**: Returns or sets the offset reverse status
- **SaveFeature**: Returns or sets the save feature flag used for creating chamfer
- **SecondOffset**: Returns or sets the second offset distance (expression).

