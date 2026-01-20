# NXOpen API Detailed Reference

This document contains detailed descriptions extracted from the official NXOpen XML documentation.

## Session

Represents the NX session.

### Members

- **AfuManager** [Property]
  - System.Xml.XmlElement
- **DexManager** [Property]
  - System.Xml.XmlElement
- **PvtransManager** [Property]
  - System.Xml.XmlElement
- **FTKManager** [Property]
  - System.Xml.XmlElement
- **Post** [Property]
  - System.Xml.XmlElement
- **ResultManager** [Property]
  - System.Xml.XmlElement
- **CaeSession** [Property]
  - System.Xml.XmlElement
- **UpdateManager** [Property]
  - System.Xml.XmlElement
- **Parts** [Property]
  - System.Xml.XmlElement
- **WeldCustomManager** [Property]
  - System.Xml.XmlElement
- **ValidationManager** [Property]
  - System.Xml.XmlElement
- **CheckerDataStatus** [Property]
  - This is an internal API and can be changed at any time
- **AutomatedTestingManager** [Property]
  - This is an internal API and can be changed at any time
- **ListingWindow** [Property]
  - System.Xml.XmlElement
- **SpreadsheetManager** [Property]
  - System.Xml.XmlElement
- **DisplayManager** [Property]
  - System.Xml.XmlElement
- **MathUtils** [Property]
  - System.Xml.XmlElement
- **EngineeringFunction** [Property]
  - System.Xml.XmlElement
- **Measurement** [Property]
  - System.Xml.XmlElement
- **Information** [Property]
  - System.Xml.XmlElement
- **Preferences** [Property]
  - Returns the preferences instance for the session
- **LogFile** [Property]
  - Returns the log file instance for this session
- **CAMSession** [Property]
  - Returns the CAM session
- **DesignRuleManager** [Property]
  - System.Xml.XmlElement
- **RouteCustomManager** [Property]
  - System.Xml.XmlElement
- **RoutingCustomManager** [Property]
  - System.Xml.XmlElement
- **MechanicalRoutingCustomManager** [Property]
  - System.Xml.XmlElement
- **OptionsManager** [Property]
  - System.Xml.XmlElement
- **LicenseManager** [Property]
  - System.Xml.XmlElement
- **UserDefinedClassManager** [Property]
  - System.Xml.XmlElement

## Part

Represents an NX part of type .prt.

### Members

- **Bodies** [Property]
  - Returns the BodyCollection instance belonging to this part
- **CutViews** [Property]
  - Returns the CutViewCollection instance belonging to this part
- **Dimensions** [Property]
  - Returns the DimensionCollection instance belonging to this part
- **DraftingViews** [Property]
  - Returns the DraftingViewCollection instance belonging to this part
- **DrawingSheets** [Property]
  - Returns the DrawingSheetCollection instance belonging to this part
- **DraftingDrawingSheets** [Property]
  - Returns the DraftingDrawingSheetCollection instance belonging to this part
- **Notes** [Property]
  - Returns a collection of notes
- **Labels** [Property]
  - Returns a collection of labels
- **Gdts** [Property]
  - Returns a collection of GDTs
- **Markers** [Property]
  - Return a collection of Markers
- **RouteManager** [Property]
  - Returns the RouteManager for this part
- **SegmentManager** [Property]
  - Returns the SegmentManager for this part
- **MechanicalRoutingCollectionsManager** [Property]
  - Returns the Routing Mechanical Collections Manager for this part
- **ElectricalRoutingCollectionsManager** [Property]
  - Returns the Routing Electrical Collections Manager for this part
- **Sketches** [Property]
  - Returns the SketchCollection instance belonging to this part
- **Tracelines** [Property]
  - Returns a collection of tracelines
- **FaceSetOffsets** [Property]
  - Returns the FaceSetOffsets instance belonging to this part
- **PackagingCollection** [Property]
  - Returns the PackagingCollection for this part
- **MotionManager** [Property]
  - Returns the MotionManager for this part
- **PhysicsManager** [Property]
  - Returns the PhysicsManager for this part
- **PenetrationManager** [Property]
  - Returns the PenetrationManager for this part
- **DraftPointData** [Property]
  - Returns the collection of DraftPointData
- **Relinkers** [Property]
  - Returns the RelinkerCollection instance belonging to this part
- **OnestepUnforms** [Property]
  - Returns the BodyDes.
- **ReusableParts** [Property]
  - Returns the AddReusablePartCollection instance belonging to this part
- **ToolingManager** [Property]
  - Returns the ToolingManager instance belonging to this part
- **SketchEvaluators** [Property]
  - Returns the collection of SketchEvaluator
- **Drafting** [Property]
  - Returns the DraftingManager for part
- **DraftingManager** [Property]
  - Returns the DraftingApplicationManager for part
- **ComponentGroups** [Property]
  - Returns the collection of ComponentGroups for this part

## BasePart

Base class for an NX part.

### Members

- **CgfxAttrs** [Property]
  - Returns the Display.
- **CgfxMattex** [Property]
  - Returns the Display.
- **WCS** [Property]
  - Returns the WCS instance belonging to this part
- **Arcs** [Property]
  - Returns the ArcCollection instance belonging to this part
- **Parabolas** [Property]
  - Returns the ParabolaCollection instance belonging to this part
- **AnalysisManager** [Property]
  - Returns the GeometricAnalysisManager for part
- **MeasureManager** [Property]
  - Returns the measure manager for this part
- **Layers** [Property]
  - Returns the LayerManager for this part
- **Xforms** [Property]
  - Returns the XformCollection instance belonging to this part
- **Offsets** [Property]
  - Returns the OffsetCollection instance belonging to this part
- **Planes** [Property]
  - Return a collection of Planes
- **Hyperbolas** [Property]
  - Returns the HyperbolaCollection instance belonging to this part
- **Curves** [Property]
  - Returns the CurveCollection instance belonging to this part
- **Points** [Property]
  - Returns the PointCollection instance belonging to this part
- **Ellipses** [Property]
  - Returns the EllipseCollection instance belonging to this part
- **Lines** [Property]
  - Returns the LineCollection instance belonging to this part
- **InfiniteLines** [Property]
  - Returns the InfiniteLineCollection instance belonging to this part
- **Splines** [Property]
  - Returns the SplineCollection instance belonging to this part
- **Polylines** [Property]
  - Returns the PolylineCollection instance belonging to this part
- **NXMatrices** [Property]
  - Returns the NXMatrixCollection instance belonging to this part
- **Scalars** [Property]
  - Returns the ScalarCollection instance belonging to this part
- **Fonts** [Property]
  - Returns the FontCollection instance belonging to this part
- **Datums** [Property]
  - Returns the DatumCollection instance belonging to this part
- **Views** [Property]
  - Returns the ViewCollection instance belonging to this part
- **ExpressionGroups** [Property]
  - Returns the ExpressionGroupCollection instance belonging to this part
- **Expressions** [Property]
  - Returns the ExpressionCollection instance belonging to this part
- **ParameterTables** [Property]
  - Returns the ParameterTableCollection instance belonging to this part
- **UnitCollection** [Property]
  - Returns a collection of Units
- **Directions** [Property]
  - Returns the DirectionCollection instance belonging to this part
- **ModelingViews** [Property]
  - Returns the ModelingViewCollection instance belonging to this part

## Body

Represents a Body

### Members

- **GetFeatures** [Method]
  - Returns the features used to construct the body
- **GetFaces** [Method]
  - Returns the faces in the body
- **GetEdges** [Method]
  - Returns the edges in the body
- **RemoveMergedRibImprintedEdges(NXOpen.Face,NXOpen.Edge[])** [Method]
  - Removes imprinted edges created by the merged rib rule.
- **GetFacetedBody(NXOpen.Facet.FacetedBody@,System.Boolean@)** [Method]
  - System.Xml.XmlElement
- **SweepabilityCheck** [Method]
  - Sweepability check
- **GetNumberOfFacets** [Method]
  - Returns the number of facets on all the faces of this convergent body.
- **GetNumberOfVertices** [Method]
  - Returns the number of vertices on all the faces of this convergent body.
- **GetNextFacet(NXOpen.ConvergentFacet)** [Method]
  - Returns a facet next to given facet on convergent body.
- **GetFirstFacetOnBody** [Method]
  - Returns first facet on a convergent body.
- **Density** [Property]
  - Returns or sets the solid density of the body.
- **IsConvergentBody** [Property]
  - Returns true if the body is a convergent body.
- **IsSheetBody** [Property]
  - Returns true if the body is a sheet body
- **IsSolidBody** [Property]
  - Returns true if the body is a solid body

## Face

Represents a face

### Members

- **GetEdges** [Method]
  - Returns the edges in the face
- **GetUnsortedEdges** [Method]
  - Returns the edges in the face
- **GetBody** [Method]
  - Returns the body containing this face
- **GetNumberOfFacets** [Method]
  - Returns the number of facets on a convergent face.
- **GetNumberOfVertices** [Method]
  - Returns the number of vertices on this convergent face.
- **GetNextFacet(NXOpen.ConvergentFacet)** [Method]
  - Returns a facet next to the input facet on a convergent face.
- **GetFirstFacetOnFace** [Method]
  - Returns first facet on convergent face.
- **DestroyOwnedFacets** [Method]
  - System.Xml.XmlElement
- **GetChamferData(NXOpen.Face.ChamferType@,System.Double[]@)** [Method]
  - Check whether a face is chamfer and return the chamfer data for chamfer face
- **GetBlendData(System.Double@,System.Boolean@)** [Method]
  - Identify blend face and get it's radius
- **GetHoleData(System.Boolean@)** [Method]
  - Get Hole Data if the face is one of a face from a hole.
- **SolidFaceType** [Property]
  - Returns the Parasolid type of the face

## Edge

Represents an edge

### Members

- **GetFaces** [Method]
  - Returns the faces connected to the edge.
- **GetUnsortedFaces** [Method]
  - Returns the faces connected to the edge.
- **GetVertices(NXOpen.Point3d@,NXOpen.Point3d@)** [Method]
  - Returns the vertices of the edge.
- **GetBody** [Method]
  - Returns the body containing this edge
- **SolidEdgeType** [Property]
  - Returns the solid type of the edge
- **GetDraftingCurveInfo** [Method]
  - Creates new DraftingCurveInfo object
- **IsDraftingCurve** [Method]
  - Checks if an object is a Drafting Curve
- **GetLength** [Method]
  - Returns the length of the object
- **GetLocations** [Method]
  - Finds the locations associated with this curve
- **IsReference** [Property]
  - Returns the reference state of a curve

## Point

System.Xml.XmlElement

### Members

- **SetCoordinates(NXOpen.Point3d)** [Method]
  - Sets the coordinates of the point
- **SetPointOnCurveTParameterFixed(System.Boolean)** [Method]
  - Sets the T parameter of the point created using point on curve method
- **Coordinates** [Property]
  - Returns the coordinates of the point
- **IsReference** [Property]
  - Returns the reference state of a point.

## Curve

Represents a curve.

### Members

- **GetDraftingCurveInfo** [Method]
  - Creates new DraftingCurveInfo object
- **IsDraftingCurve** [Method]
  - Checks if an object is a Drafting Curve
- **GetLength** [Method]
  - Returns the length of the object
- **GetLocations** [Method]
  - Finds the locations associated with this curve
- **IsReference** [Property]
  - Returns the reference state of a curve

## Line

Represents a line curve.

### Members

- **SetStartPoint(NXOpen.Point3d)** [Method]
  - Sets the start point of the line
- **SetEndPoint(NXOpen.Point3d)** [Method]
  - Sets the end point of the line
- **SetEndpoints(NXOpen.Point3d,NXOpen.Point3d)** [Method]
  - Sets the start and end points of the line
- **EndPoint** [Property]
  - Returns the end point of the line
- **StartPoint** [Property]
  - Returns the start point of the line

## Arc

Represents an arc curve.

### Members

- **SetRadius(System.Double)** [Method]
  - Sets the radius of the arc.
- **SetParameters(System.Double,NXOpen.Point3d,System.Double,System.Double,NXOpen.NXMatrix)** [Method]
  - Sets the center, radius, start and end angles, and orientation matrix of the arc.
- **SetParameters(System.Double,NXOpen.Point3d,System.Double,System.Double)** [Method]
  - Sets the center, radius, and start and end angles of the arc.
- **EndAngle** [Property]
  - Returns the angle of the arc.
- **Radius** [Property]
  - Returns the radius of the arc.
- **StartAngle** [Property]
  - Returns the start angle of the arc.

## Spline

Represents a spline curve.

### Members

- **GetKnots** [Method]
  - Returns the knots
- **GetPoles** [Method]
  - Returns the homogeneous poles.
- **Get3DPoles** [Method]
  - Returns poles in three-dimensional cartesian coordinates of a normalized representation of the spline.
- **GetDefiningPoints** [Method]
  - Returns defining points if spline has associated defining data.
- **Order** [Property]
  - Returns the order of the spline
- **Periodic** [Property]
  - Returns the periodicity of the spline
- **PoleCount** [Property]
  - Returns the number of poles, includes the duplicates in case of periodic spline.
- **Rational** [Property]
  - Returns the rationality of the spline

## Expression

Represents an expression.

### Members

- **GetFormula** [Method]
  - Get the formula part of the expression string: "name = formula".
- **SetFormula(System.String)** [Method]
  - Set the formula part of the expression string: "name = formula".
- **SetNumberValueWithUnits(System.Double,NXOpen.Unit)** [Method]
  - Set the value of a number expression in specified units.
- **GetNumberValueWithUnits(NXOpen.Expression.UnitsOption,System.Double@,NXOpen.Unit@)** [Method]
  - Get the number value of a number expression in specified units.
- **GetPointValueWithUnits(NXOpen.Expression.UnitsOption)** [Method]
  - Get the value of a point expression in the specified units.
- **GetVectorValueWithUnits(NXOpen.Expression.UnitsOption)** [Method]
  - Get the value of a vector expression in specified units.
- **GetListValue** [Method]
  - Get the value of a list expression.
- **GetPersistentlyLocked** [Method]
  - Check whether the expression is persistently locked.
- **SetPersistentlyLocked(System.Boolean)** [Method]
  - Set the expression's persistently locked state.
- **EditComment(System.String)** [Method]
  - Changes the comment.
- **GetUsingFeatures** [Method]
  - Returns an array of the features that use the supplied expression.
- **GetOwningFeature** [Method]
  - Returns the feature that created the supplied expression.
- **GetOwningRpoFeature** [Method]
  - Returns the feature whose rpo_transform created the supplied positioning dimension expression.
- **GetDescriptor** [Method]
  - Returns the descriptor for the expression, or a null reference (Nothing in Visual Basic) if there is no descriptor.
- **GetReferencingExpressions** [Method]
  - Returns all the referencing expressions of the expression
- **GetInterpartExpressionNames(System.String@,System.String@)** [Method]
  - The source part name and source expression name of the interpart expression
- **GetValueUsingUnits(NXOpen.Expression.UnitsOption)** [Method]
  - Get the value of the expression in specified units.
- **MakeConstant** [Method]
  - Make the expression constant.
- **HasReferencedAttribute** [Method]
  - Does the expression reference an attribute?
- **GetReferencedAttribute** [Method]
  - System.Xml.XmlElement
- **HasReferencingPartAttribute** [Method]
  - Does a part attribute reference an expression?
- **HasReferencingObjectAttribute** [Method]
  - Does an object attribute reference an expression?
- **GetReferencingAttribute(NXOpen.Expression.AttributeSourceType,NXOpen.NXObject.AttributeInformation@)** [Method]
  - System.Xml.XmlElement
- **GetReferencingPartOrObjectAttribute(NXOpen.Expression.AttributeSourceType@,NXOpen.NXObject.AttributeInformation@)** [Method]
  - System.Xml.XmlElement
- **GetFormulaDescription** [Method]
  - Get Expression rhs (formula) information.
- **BooleanValue** [Property]
  - Returns the value of a boolean expression.
- **Description** [Property]
  - Returns the description of the expression.
- **Equation** [Property]
  - Returns the expression as a string in the form: "name = formula".
- **ExpressionString** [Property]
  - Returns the expression as a string in the form: "name = formula".
- **IntegerValue** [Property]
  - Returns the value of an integer expression.

## NXObject

A base class providing low-level services for most NXOpen classes.

### Members

- **SetUserAttribute(NXOpen.NXObject.AttributeInformation,NXOpen.Update.Option)** [Method]
  - Creates or modifies an attribute with the option to update or not.
- **SetUserAttribute(System.String,System.Int32,System.Int32,NXOpen.Update.Option)** [Method]
  - Creates or modifies an integer attribute with the option to update or not.
- **SetUserAttribute(System.String,System.Int32,System.Double,NXOpen.Update.Option)** [Method]
  - Creates or modifies a real attribute with the option to update or not.
- **SetUserAttribute(System.String,System.Int32,System.String,NXOpen.Update.Option)** [Method]
  - Creates or modifies a string attribute with the option to update or not.
- **SetUserAttribute(System.String,System.Int32,NXOpen.Update.Option)** [Method]
  - Creates or modifies a null attribute with the option to update or not.
- **SetTimeUserAttribute(System.String,System.Int32,System.String,NXOpen.Update.Option)** [Method]
  - Creates or modifies a time attribute with the option to update or not.
- **SetTimeUserAttribute(System.String,System.Int32,NXOpen.NXObject.ComputationalTime,NXOpen.Update.Option)** [Method]
  - Creates or modifies a time attribute with the option to update or not.
- **SetBooleanUserAttribute(System.String,System.Int32,System.Boolean,NXOpen.Update.Option)** [Method]
  - Creates or modifies a boolean attribute with the option to update or not.
- **CreateAttributeIterator** [Method]
  - Create an attribute iterator
- **HasUserAttribute(NXOpen.AttributeIterator)** [Method]
  - Determines if an attribute exists on the object, that satisfies the given iterator
- **HasUserAttribute(System.String,NXOpen.NXObject.AttributeType,System.Int32)** [Method]
  - Determines if an attribute with the given Title, Type and array Index is present on the object Unset attributes will not be detected by this function, as its purpose is to test for the actual presence of the attribute on the object.
- **GetUserAttributeCount(NXOpen.AttributeIterator)** [Method]
  - Gets the count of set attributes on the object, if any, that satisfy the given iterator.
- **GetUserAttributeCount(NXOpen.AttributeIterator,System.Boolean)** [Method]
  - Gets the count of set attributes on the object, if any, that satisfy the given iterator.
- **GetUserAttributeCount(NXOpen.NXObject.AttributeType)** [Method]
  - Gets the count of set attributes on the object, if any, of the given type.
- **GetUserAttributeCount(NXOpen.NXObject.AttributeType,System.Boolean,System.Boolean)** [Method]
  - Gets the count of attributes on the object, if any, of the given type.
- **GetUserAttributeSize(System.String,NXOpen.NXObject.AttributeType)** [Method]
  - Gets the size of the first attribute encountered on the object, if any, with a given Title and Type.
- **GetNextUserAttribute(NXOpen.AttributeIterator,NXOpen.NXObject.AttributeInformation@)** [Method]
  - Gets the next attribute encountered on the object, if any, that satisfies the given iterator.
- **GetUserAttribute(System.String,NXOpen.NXObject.AttributeType,System.Int32)** [Method]
  - Gets the first attribute encountered on the object, if any, with a given Title, Type and array Index.
- **GetBooleanUserAttribute(System.String,System.Int32)** [Method]
  - Gets a boolean attribute by Title and array Index.
- **GetIntegerUserAttribute(System.String,System.Int32)** [Method]
  - Gets an integer attribute by Title and array Index.
- **GetRealUserAttribute(System.String,System.Int32)** [Method]
  - Gets a real attribute by Title and array Index.
- **GetStringUserAttribute(System.String,System.Int32)** [Method]
  - Gets a string attribute by Title and array Index.
- **GetTimeUserAttribute(System.String,System.Int32)** [Method]
  - Gets a time attribute by Title and array Index.
- **GetComputationalTimeUserAttribute(System.String,System.Int32)** [Method]
  - Gets a time attribute by Title and array Index.
- **GetUserAttributes(NXOpen.AttributeIterator)** [Method]
  - Gets all the attributes that have been set on the given object, if any, that satisfy the given iterator.
- **GetUserAttributes** [Method]
  - Gets all the attributes that have been set on the given object.
- **GetUserAttributes(System.Boolean)** [Method]
  - Gets all the attributes of the given object.
- **GetUserAttributeAsString(System.String,NXOpen.NXObject.AttributeType,System.Int32)** [Method]
  - Gets the first attribute encountered on the object, if any, with a given title, type and array index.
- **DeleteUserAttributes(NXOpen.AttributeIterator,NXOpen.Update.Option)** [Method]
  - Deletes the attributes on the object, if any, that satisfy the given iterator
- **DeleteUserAttribute(NXOpen.NXObject.AttributeType,System.String,System.Boolean,NXOpen.Update.Option)** [Method]
  - Deletes the first attribute encountered with the given Type, Title.

## Builder

A Builder is an object that is used to create and edit other objects.

### Members

- **Commit** [Method]
  - Commits any edits that have been applied to the builder.
- **Destroy** [Method]
  - Deletes the builder, and cleans up any objects created by the builder.
- **GetCommittedObjects** [Method]
  - For builders that create more than one object, this method returns the objects that are created by commit.
- **GetObject** [Method]
  - Returns the object currently being edited by this builder.
- **ShowResults** [Method]
  - Updates the model to reflect the result of an edit to the model for all builders that support showing results.
- **PreviewBuilder** [Property]
  - Returns the preview builder subobject.
- **Validate** [Method]
  - Validate whether the inputs to the component are sufficient for commit to be called.

## Features.Feature

Represents a feature on a part

### Members

- **GetExpressions** [Method]
  - Returns the expressions created by the feature.
- **GetBodies** [Method]
  - Returns the bodies created by the feature
- **GetFaces** [Method]
  - Returns the faces created by the feature
- **GetEdges** [Method]
  - Returns the edges created by the feature
- **GetParents** [Method]
  - Returns the immediate parent features.
- **GetChildren** [Method]
  - Returns the immediate child features.
- **GetAllChildren** [Method]
  - Returns all immediate child features.
- **Highlight** [Method]
  - Highlight the body created by the feature
- **Unhighlight** [Method]
  - Unhighlight the body created by the feature
- **MakeCurrentFeature** [Method]
  - Make current feature
- **ShowBody(System.Boolean)** [Method]
  - Show the body created by the feature.
- **ShowParents(System.Boolean)** [Method]
  - Show the body created by the parent feature.
- **HideBody** [Method]
  - Hide the body created by the feature
- **HideParents** [Method]
  - Hide the body created by the parent feature
- **Suppress** [Method]
  - Suppress the feature
- **Unsuppress** [Method]
  - Unsuppress the feature
- **GetEntities** [Method]
  - Returns the entities created by a feature that are not Bodies, Faces or Edges.
- **GetFeatureErrorMessages** [Method]
  - Returns the feature error messages.
- **GetFeatureInformationalMessages** [Method]
  - Returns the feature informational messages.
- **DeleteInformationalAlerts** [Method]
  - Delete all informational alerts from the features
- **DeleteWarningAlerts** [Method]
  - Delete all warning alerts from the features
- **GetFeatureWarningMessages** [Method]
  - Returns the feature warning messages.
- **GetFeatureClueMessages** [Method]
  - Returns the feature clue messages.
- **DeleteClueAlerts** [Method]
  - Delete all clue alerts from the features
- **GetFeatureClueHintMessages** [Method]
  - Returns both clue and hint messages of the feature.
- **GetFeatureHintMessages** [Method]
  - Returns the feature hint messages.
- **DeleteHintAlerts** [Method]
  - Delete all clue alerts from the features
- **MakeSketchInternal** [Method]
  - Make the parent sketch internal if referenced only by this feature.
- **MakeSketchExternal** [Method]
  - Make the parent sketch external for reuse by other features.
- **RemoveForEdit(System.Boolean)** [Method]
  - Remove all the feature faces before a NoHistory mode edit.

## Features.FeatureCollection

Represents a collection of features

### Members

- **EnumerateMoveNext(NXOpen.Tag@,System.Byte[])** [Method]
  - Advances the enumerator to the next element of the collection.
- **ToArray** [Method]
  - System.Xml.XmlElement
- **Tag** [Property]
  - Returns the tag of this object.
- **SheetmetalManager** [Property]
  - Returns the Straight Brake Sheetmetal Manager for this part
- **AeroSheetmetalManager** [Property]
  - Returns the aerospace sheet metal manager for this part
- **Dies** [Property]
  - Returns the DieCollection instance belonging to this part
- **WeldManager** [Property]
  - Returns the WeldManager for this part
- **AutomotiveCollection** [Property]
  - Returns the AutomotiveCollection instance belonging to this part
- **ShipCollection** [Property]
  - Returns the ShipCollection instance belonging to this part
- **ToolingCollection** [Property]
  - Returns the ToolingCollection instance belonging to this part
- **SynchronousEdgeCollection** [Property]
  - Returns the SynchronousEdgeCollection instance belonging to this part
- **SweepFeatureCollection** [Property]
  - Returns the Sweep-like features collection belonging to this part
- **SynchronousCurveCollection** [Property]
  - Returns the SynchronousCurveCollection instance belonging to this part
- **VehicleDesignCollection** [Property]
  - Returns the VehicleDesignCollection instance belonging to this part
- **DesignFeatureCollection** [Property]
  - Returns the DesignfeatureCollection instance belonging to this part
- **FreeformCurveCollection** [Property]
  - Returns the FreeformCurveCollection instance belonging to this part
- **FreeformSurfaceCollection** [Property]
  - Returns the FreeformSurfaceCollection instance belonging to this part
- **TrimFeatureCollection** [Property]
  - Returns the TrimfeatureCollection instance belonging to this part
- **ToolingFeatureCollection** [Property]
  - Returns the ToolingFeatureCollection instance belonging to this part
- **CustomAttributeCollection** [Property]
  - Returns the CustomAttributeCollection instance belonging to this part
- **AeroCollection** [Property]
  - Returns the AeroCollection instance belonging to this part
- **CurveFeatureCollection** [Property]
  - Returns the CurveFeatureCollection instance belonging to this part
- **GeodesicSketchCollection** [Property]
  - Returns the GeodesicSketchCollection instance belonging to this part
- **CustomFeatureDataCollection** [Property]
  - Returns the CustomFeatureDataCollection instance belonging to this part
- **LatticeFeatureCollection** [Property]
  - Returns the LatticeFeatureCollection instance belonging to this part
- **PrintCsysFeatureCollection** [Property]
  - Returns the PrintCsysFeatureCollection instance belonging to this part
- **DetailFeatureCollection** [Property]
  - Returns the DetailfeatureCollection instance belonging to this part
- **MorphMeshCollection** [Property]
  - Returns the MorphMeshCollection instance belonging to this part
- **StructureDesignCollection** [Property]
  - Returns the StructureDesignCollection instance belonging to this part
- **AECDesignCollection** [Property]
  - Returns the AECDesignCollection instance belonging to this part

## Features.ExtrudeBuilder

Represents a extrude feature builder.

### Members

- **SetToleranceValues(System.Double,System.Double,System.Double,System.Double)** [Method]
  - SET all the tolerances at once
- **AllowSelfIntersectingSection(System.Boolean)** [Method]
  - SET option for supporting self-intersecting section
- **AngularTolerance** [Property]
  - Returns or sets the angle tolerance
- **BooleanOperation** [Property]
  - Returns the extrude boolean operation
- **ChainingTolerance** [Property]
  - Returns or sets the chaining tolerance
- **Direction** [Property]
  - Returns or sets the extrude direction
- **DistanceTolerance** [Property]
  - Returns or sets the distance tolerance
- **Draft** [Property]
  - Returns the extrude draft operation
- **FeatureOptions** [Property]
  - Returns the feature options
- **Limits** [Property]
  - Returns the extrude limits
- **Offset** [Property]
  - Returns the extrude Offset operation
- **PlanarTolerance** [Property]
  - Returns or sets the planar tolerance
- **Section** [Property]
  - Returns or sets the section
- **SmartVolumeProfile** [Property]
  - Returns the smart volume profile
- **SmartVolumeProfile1** [Property]
  - Returns the smart volume profile

## Features.RevolveBuilder

Represents a revolve builder.

### Members

- **SetStartLimitHelperPoint(System.Double[])** [Method]
  - If until selected option is used for start limit and the selected entity intersects the revolve multiple times, this point (in parasolid units) will help the system determine which intersection to select.
- **SetEndLimitHelperPoint(System.Double[])** [Method]
  - If until selected option is used for end limit and the selected entity intersects the revolve multiple times, this point (in parasolid units) will help the system determine which intersection to select.
- **Axis** [Property]
  - Returns or sets the revolve axis
- **BooleanOperation** [Property]
  - Returns the revolve boolean
- **FeatureOptions** [Property]
  - Returns the feature options
- **Limits** [Property]
  - Returns the limit data
- **Offset** [Property]
  - Returns the revolve offset
- **Section** [Property]
  - Returns or sets the section
- **SmartVolumeProfile** [Property]
  - Returns the smart volume profile
- **Tolerance** [Property]
  - Returns or sets the revolve tolerance

## Features.BooleanBuilder

Represents a boolean feature builder.

### Members

- **BooleanRegionSelect** [Property]
  - Returns the boolean region select object
- **ConvertToSew** [Property]
  - Returns or sets the convert to sew flag
- **CopyTargets** [Property]
  - Returns or sets the copy targets flag
- **CopyTools** [Property]
  - Returns or sets the copy tools flag
- **Operation** [Property]
  - Returns or sets the boolean operation
- **RemoveTargetVoids** [Property]
  - Returns or sets the remove target voids flag for Transfer Voids
- **RetainTarget** [Property]
  - Returns or sets the retain target flag
- **RetainTool** [Property]
  - Returns or sets the retain tool flag
- **Target** [Property]
  - Returns or sets the target body
- **TargetBodyCollector** [Property]
  - Returns or sets the target body collector for the boolean operation
- **Targets** [Property]
  - Returns the target bodies for the boolean operation
- **Tolerance** [Property]
  - Returns or sets the tolerance
- **Tolerance1** [Property]
  - Returns or sets the tolerance
- **Tool** [Property]
  - Returns or sets the tool body
- **ToolBodyCollector** [Property]
  - Returns or sets the tool body collector for the boolean operation
- **ToolBodyCollector1** [Property]
  - Returns or sets the tool body collector for the boolean operation
- **Tools** [Property]
  - Returns the tool bodies for the boolean operation for versions before 7.

## Features.ChamferBuilder

Represents the chamfer builder data.

### Members

- **CreatePreview** [Method]
  - Creates the chamfer preview body
- **AllInstances** [Property]
  - Returns or sets the chamfer all instance status
- **Angle** [Property]
  - Returns or sets the chamfer angle (expression).
- **AngleExp** [Property]
  - Returns the angle expression object of chamfer.
- **FirstOffset** [Property]
  - Returns or sets the first offset distance (expression).
- **FirstOffsetExp** [Property]
  - Returns the first offset expression object of chamfer.
- **Method** [Property]
  - Returns or sets the offset method.
- **Option** [Property]
  - Returns or sets the chamfer parameter option.
- **ReverseOffsets** [Property]
  - Returns or sets the offset reverse status
- **SaveFeature** [Property]
  - Returns or sets the save feature flag used for creating chamfer
- **SecondOffset** [Property]
  - Returns or sets the second offset distance (expression).
- **SecondOffsetExp** [Property]
  - Returns the second offset expression object of chamfer.
- **SmartCollector** [Property]
  - Returns or sets the smart collector
- **Tolerance** [Property]
  - Returns or sets the tolerance used for creating chamfer

## Features.EdgeBlendBuilder

Represents a Edge Blend builder.

### Members

- **AddChainset(NXOpen.ScCollector,System.String)** [Method]
  - Add an edge blend chainset to the edge blend
- **AddChainset(NXOpen.ScCollector,NXOpen.Features.EdgeBlendBuilder.Section,NXOpen.Features.EdgeBlendBuilder.Conic,NXOpen.Features.EdgeBlendBuilder.Rhotype,System.String,System.String,System.String)** [Method]
  - Add an edge blend chainset to the edge blend
- **GetChainsetIndex(NXOpen.ScCollector)** [Method]
  - Get the index of edge blend chainset given the collector
- **GetNumberOfValidChainsets** [Method]
  - Get the number of valid chainsets
- **GetChainset(System.Int32,NXOpen.ScCollector@,NXOpen.Expression@)** [Method]
  - Get collector and radius for an edge blend chainset given the index of the chainset
- **GetChainsetAndSectionValue(System.Int32,NXOpen.ScCollector@,NXOpen.Features.EdgeBlendBuilder.Section@,NXOpen.Features.EdgeBlendBuilder.Conic@,NXOpen.Features.EdgeBlendBuilder.Rhotype@,NXOpen.Expression@,NXOpen.Expression@,NXOpen.Expression@)** [Method]
  - Get collector, radius and section types for an edge blend chainset given the index of the chainset
- **GetChainsetAndStatus(System.Int32,NXOpen.ScCollector@,NXOpen.Expression@,System.Boolean@)** [Method]
  - Get collector, radius and validity status for an edge blend chainset given the index of the chainset
- **RemoveChainset(System.Int32)** [Method]
  - Delete an edge blend chainset from the edge blend.
- **RemoveChainsetByCollector(NXOpen.ScCollector)** [Method]
  - Delete an edge blend chainset from the edge blend.
- **GetSetbackData(System.Int32,System.Boolean[]@,NXOpen.Expression[]@)** [Method]
  - Get an edge blend setback data for the index provided
- **AddSetbackData(NXOpen.Edge[],System.Boolean[],System.String[])** [Method]
  - Add an edge blend setback data for an edge in the edge blend
- **RemoveSetbackData(System.Int32)** [Method]
  - Remove an edge blend setback data for an edge in the edge blend
- **GetNewStopshortData(System.Int32)** [Method]
  - Get an edge blend stop short data for the index provided
- **GetStopshortData(System.Int32,NXOpen.Edge@,System.Boolean@)** [Method]
  - Get an edge blend stop short data for the index provided
- **AddNewStopshortData(NXOpen.GeometricUtilities.BlendStopshortBuilder)** [Method]
  - Add an edge blend stop short data for an edge in the edge blend
- **AddStopshortData(NXOpen.Edge,System.Boolean,System.String)** [Method]
  - Add an edge blend stop short data for an edge in the edge blend
- **RemoveStopshortData(NXOpen.Edge,System.Boolean)** [Method]
  - Remove an edge blend stop short data for an edge
- **RemoveStopshortDataByType(NXOpen.Edge,System.Boolean,NXOpen.GeometricUtilities.BlendStopshortBuilder.Choices)** [Method]
  - Remove the stop short from an edge, given its type and location
- **RemoveNewStopshortData(NXOpen.GeometricUtilities.BlendStopshortBuilder)** [Method]
  - Remove an edge blend stop short corresponding to a BlendStopshortBuilder
- **RemoveStopshortData(System.Int32)** [Method]
  - Remove an edge blend stop short data for the index indicated
- **GetVariableRadiusData(NXOpen.Edge,NXOpen.Expression[]@,NXOpen.Point[]@,System.Boolean[]@)** [Method]
  - Get all the variable radii data for an edge in the edge blend
- **GetVariableRadiusDataNew(NXOpen.Edge,NXOpen.Expression[]@,NXOpen.Expression[]@,NXOpen.Point[]@,System.Boolean[]@)** [Method]
  - Get all the variable radii data for an edge in the edge blend
- **AddVariableRadiusData(NXOpen.Edge,System.Double,System.String,NXOpen.Point,System.Boolean)** [Method]
  - Add an edge blend variable radius data for an edge in the edge blend
- **AddVariableRadiusDataNew(NXOpen.Edge,System.String,System.String,NXOpen.Point,System.Boolean)** [Method]
  - Add an edge blend variable radius data for an edge in the edge blend * Note: This ja will always create arclength parameter
- **AddVariableRadiusDataNew(NXOpen.Edge,System.String,System.String,NXOpen.Point,System.Boolean,System.Boolean)** [Method]
  - Add an edge blend variable radius data for an edge in the edge blend
- **AddVariablePointData(NXOpen.Edge,System.String,System.String,System.String,System.String,NXOpen.Point,System.Boolean,System.Boolean)** [Method]
  - Add an edge blend variable radius data for an edge in the edge blend
- **EditVariableRadiusData(NXOpen.Edge,System.Int32,System.Double,System.String,NXOpen.Point,System.Boolean)** [Method]
  - Edit an edge blend variable radius data for an edge in the edge blend
- **EditVariableRadiusDataNew(NXOpen.Edge,System.Int32,System.String,System.String,NXOpen.Point,System.Boolean)** [Method]
  - Edit an edge blend variable radius data for an edge in the edge blend
- **EditVariableRadiusDataNew(NXOpen.Edge,System.Int32,System.String,System.String,NXOpen.Point,System.Boolean,System.Boolean)** [Method]
  - Edit an edge blend variable radius data for an edge in the edge blend
- **EditVariablePointData(NXOpen.Edge,System.Int32,System.String,System.String,System.String,System.String,NXOpen.Point,System.Boolean,System.Boolean)** [Method]
  - Edit an edge blend variable radius data for an edge in the edge blend

## Features.HoleFeatureBuilder

Represents a Hole feature builder.

### Members

- **GetThruFace** [Method]
  - Returns thru face parameter for the hole.
- **SetThruFace(NXOpen.ISurface)** [Method]
  - Sets thru face parameter for the hole.
- **GetTargetBody** [Method]
  - Returns target body for the hole.
- **SetTargetBody(NXOpen.Body)** [Method]
  - Sets target body for the hole.
- **SetDepth(System.String)** [Method]
  - Sets the depth of the hole.
- **SetTipAngle(System.String)** [Method]
  - Sets the tip angle of the hole.
- **SetDiameter(System.String)** [Method]
  - Sets the diameter of the hole.
- **SetCounterboreDiameter(System.String)** [Method]
  - Sets the diameter of the counterbore for a hole.
- **SetCounterboreDepth(System.String)** [Method]
  - Sets the depth of the counterbore for a hole.
- **SetCountersinkDiameter(System.String)** [Method]
  - Sets the diameter of the countersink for a hole.
- **SetCountersinkAngle(System.String)** [Method]
  - Sets the angle of the countersink for a hole.
- **CreateHole** [Method]
  - Creates a hole body which can be positioned
- **SetDepthAndTipAngle(System.String,System.String)** [Method]
  - Sets depth and tip angle parameters for the hole.
- **SetSimpleHole(NXOpen.Point3d,System.Boolean,NXOpen.ISurface,System.String)** [Method]
  - Sets parameters for simple hole
- **SetCounterboreHole(NXOpen.Point3d,System.Boolean,NXOpen.ISurface,System.String,System.String,System.String)** [Method]
  - Sets parameters for counterbore hole
- **SetCountersinkHole(NXOpen.Point3d,System.Boolean,NXOpen.ISurface,System.String,System.String,System.String)** [Method]
  - Sets parameters for countersink hole
- **CounterboreDepth** [Property]
  - Returns the depth of the counterbore for a hole.
- **CounterboreDiameter** [Property]
  - Returns the diameter of the counterbore for a hole.
- **CountersinkAngle** [Property]
  - Returns the angle of the countersink for a hole.
- **CountersinkDiameter** [Property]
  - Returns the diameter of the countersink for a hole.
- **Depth** [Property]
  - Returns the depth of the hole.
- **Diameter** [Property]
  - Returns the diameter of the hole.
- **HoleLocation** [Property]
  - Returns or sets the reference point of the hole.
- **PlacementFace** [Property]
  - Returns or sets the placement face of the hole.
- **ReverseDirection** [Property]
  - Returns or sets the reverse direction flag of the hole.
- **Subtype** [Property]
  - Returns or sets the type of hole
- **TipAngle** [Property]
  - Returns the tip angle of the hole.

## Features.BlockFeatureBuilder

Represents a block feature builder.

### Members

- **GetOrientation(NXOpen.Vector3d@,NXOpen.Vector3d@)** [Method]
  - Gets the orientation (x and y axes) of the block.
- **SetLength(System.String)** [Method]
  - The expression representing the block length.
- **SetWidth(System.String)** [Method]
  - The expression representing the block width.
- **SetHeight(System.String)** [Method]
  - The expression representing the block height.
- **SetOrientation(NXOpen.Vector3d,NXOpen.Vector3d)** [Method]
  - Sets the orientation for the block
- **SetOriginAndLengths(NXOpen.Point3d,System.String,System.String,System.String)** [Method]
  - Create a block by setting the origin and the block length, width, and height.
- **SetTwoPointsAndHeight(NXOpen.Point3d,NXOpen.Point3d,System.String)** [Method]
  - Create a block by setting the block height and two diagonal points in the WCS x-y plane.
- **SetTwoDiagonalPoints(NXOpen.Point3d,NXOpen.Point3d)** [Method]
  - Create a block by setting two diagonal points, one at the block origin and one at the opposite corner point.
- **SetBooleanOperationAndTarget(NXOpen.Features.Feature.BooleanType,NXOpen.Body)** [Method]
  - Set the boolean operation for creating the block and the boolean operation target body
- **BooleanOption** [Property]
  - Returns the boolean option
- **BooleanType** [Property]
  - Returns or sets the boolean operation for the block
- **Height** [Property]
  - Returns the expression representing the block height.
- **Length** [Property]
  - Returns the expression representing the block length.
- **Origin** [Property]
  - Returns or sets the point coordinates representing the block origin.
- **OriginPoint** [Property]
  - Returns or sets the block origin point
- **ParentAssociativity** [Property]
  - Returns or sets the option to keep associativity of the Origin and Origin Offset Points
- **PointFromOrigin** [Property]
  - Returns or sets the point which defines values along the x, y axes of the WCS from origin point, when type is two point and height.
- **Target** [Property]
  - Returns or sets the target body for the boolean operation (if any) for the block
- **Type** [Property]
  - System.Xml.XmlElement
- **Width** [Property]
  - Returns the expression representing the block width.

## Features.CylinderBuilder

System.Xml.XmlElement

### Members

- **Arc** [Property]
  - Returns the arc
- **Axis** [Property]
  - Returns or sets the axis
- **BooleanOption** [Property]
  - Returns the boolean option
- **Diameter** [Property]
  - Returns the diameter.
- **Direction** [Property]
  - Returns or sets the cylinder direction
- **Height** [Property]
  - Returns the height
- **Origin** [Property]
  - Returns or sets the cylinder origin
- **ParentAssociativity** [Property]
  - Returns or sets the option to keep associativity of the cylinder axis
- **ReverseDirection** [Property]
  - Returns or sets the reverse direction
- **Type** [Property]
  - Returns or sets the type

## Features.SphereBuilder

System.Xml.XmlElement

### Members

- **Arc** [Property]
  - Returns the selected arc associated with the Sphere.
- **BooleanOption** [Property]
  - Returns the boolean operation associated with the Sphere.
- **CenterPoint** [Property]
  - Returns or sets the center point of the Sphere.
- **Diameter** [Property]
  - Returns the diameter of the Sphere.
- **ParentAssociativity** [Property]
  - Returns or sets the option to keep associativity of the sphere center point
- **Type** [Property]
  - System.Xml.XmlElement

## Features.ConeBuilder

Represents a builder for a cone feature.

### Members

- **Axis** [Property]
  - Returns or sets the axis
- **BaseArc** [Property]
  - Returns the base arc
- **BaseDiameter** [Property]
  - Returns the base diameter
- **BooleanOption** [Property]
  - Returns the boolean option
- **HalfAngle** [Property]
  - Returns the half angle
- **Height** [Property]
  - Returns the height
- **ParentAssociativity** [Property]
  - Returns or sets the option to keep associativity of the cone axis
- **TopArc** [Property]
  - Returns the top arc
- **TopDiameter** [Property]
  - Returns the top diameter
- **Type** [Property]
  - System.Xml.XmlElement

## Sketch

Represents a sketch

### Members

- **Preferences** [Property]
  - Contains preferences for the sketch
- **DeleteObjects(NXOpen.NXObject[])** [Method]
  - Deletes objects from the sketch
- **Reattach(NXOpen.ISurface,NXOpen.IReferenceAxis,NXOpen.Vector3d,NXOpen.AxisOrientation,NXOpen.Sense,NXOpen.PlaneNormalOrientation,NXOpen.Point3d)** [Method]
  - Reattaches a sketch.
- **Activate(NXOpen.Sketch.ViewReorient)** [Method]
  - Activates the sketch
- **Deactivate(NXOpen.Sketch.ViewReorient,NXOpen.Sketch.UpdateLevel)** [Method]
  - Deactivates the sketch
- **SetReferenceDirection(NXOpen.IReferenceAxis,NXOpen.Vector3d,NXOpen.AxisOrientation,NXOpen.Sense)** [Method]
  - Sets the reference direction of the sketch.
- **FlipReferenceDirection** [Method]
  - Flips the reference direction of the sketch
- **FlipNormal** [Method]
  - Flips the outward normal vector of the sketch
- **GetReferenceDirection(NXOpen.IReferenceAxis@,NXOpen.AxisOrientation@,NXOpen.Sense@)** [Method]
  - Gets the reference direction of the sketch
- **RunAutoDimension** [Method]
  - Run auto dimensioning.
- **CreateCoincidentConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a coincident constraint
- **CreateFixedConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a fixed constraint
- **CreateFullyFixedConstraints(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates enough fixed constraints on the curve and all of its vertices such that the geometry is fully fixed without any redundant fixed constraints.
- **CreateHorizontalConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a horizontal constraint
- **CreateVerticalConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a vertical constraint
- **CreateTangentConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometryHelp,NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometryHelp)** [Method]
  - Creates a tangent constraint.
- **CreateConstantLengthConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a constant length constraint
- **CreateConstantAngleConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a constant angle constraint
- **CreateUniformScaledConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a uniform scale constraint
- **CreateNonUniformScaledConstraint(NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a non-uniform scale constraint
- **CreateParallelConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a parallel constraint.
- **CreatePerpendicularConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a perpendicular constraint.
- **CreateNormalConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometryHelp,NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometryHelp)** [Method]
  - Creates a normal constraint.
- **CreateCollinearConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a collinear constraint.
- **CreateEqualLengthConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates an equal length constraint.
- **CreateEqualRadiusConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates an equal radius constraint.
- **CreateConcentricConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a concentric constraint.
- **CreateMidpointConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a midpoint constraint.
- **CreateSlopeConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry)** [Method]
  - Creates a slope constraint.
- **CreatePointOnCurveConstraint(NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometry,NXOpen.Sketch.ConstraintGeometryHelp)** [Method]
  - Creates a point on curve constraint.

## SketchCollection

Represents a collection of sketches

### Members

- **EnumerateMoveNext(NXOpen.Tag@,System.Byte[])** [Method]
  - Advances the enumerator to the next element of the collection.
- **ToArray** [Method]
  - System.Xml.XmlElement
- **Tag** [Property]
  - Returns the tag of this object.
- **FindObject(System.String)** [Method]
  - System.Xml.XmlElement
- **GetOwningSketch(NXOpen.SmartObject)** [Method]
  - Returns the sketch that owns the specified geometry
- **GetDimensionPreviewer** [Method]
  - This is an internal API and can be changed at any time
- **CreateIntersectionCurveBuilder(NXOpen.SketchIntersectionCurve)** [Method]
  - Creates the builder for intersection curve
- **CreateIntersectionPointBuilder(NXOpen.SketchIntersectionPoint)** [Method]
  - Creates the builder for intersection point
- **CreateProjectBuilder(NXOpen.Features.Feature)** [Method]
  - System.Xml.XmlElement
- **CreateCornerBuilder** [Method]
  - System.Xml.XmlElement
- **CreateAutoConstrainBuilder** [Method]
  - System.Xml.XmlElement
- **CreateSketchOffsetBuilder(NXOpen.SketchOffset)** [Method]
  - System.Xml.XmlElement
- **CreateSketchAssociativeTrimBuilder(NXOpen.SketchAssociativeTrim)** [Method]
  - System.Xml.XmlElement
- **CreateConvertToFromReferenceBuilder** [Method]
  - System.Xml.XmlElement
- **CreateInferredConstraintsBuilder** [Method]
  - System.Xml.XmlElement
- **CreateDimensionBuilder(NXOpen.SketchDimensionalConstraint)** [Method]
  - System.Xml.XmlElement
- **CreateQuickExtendBuilder** [Method]
  - System.Xml.XmlElement
- **CreateQuickTrimBuilder** [Method]
  - System.Xml.XmlElement
- **CreateNewSketchInPlaceBuilder(NXOpen.Sketch)** [Method]
  - System.Xml.XmlElement
- **CreateSketchInPlaceBuilder2(NXOpen.Sketch)** [Method]
  - System.Xml.XmlElement
- **CreateSimpleSketchInPlaceBuilder** [Method]
  - System.Xml.XmlElement
- **CreateSketchAlongPathBuilder(NXOpen.Sketch)** [Method]
  - System.Xml.XmlElement
- **CreateSketchInDraftingBuilder** [Method]
  - System.Xml.XmlElement
- **CreateSketchEllipseBuilder(NXOpen.NXObject)** [Method]
  - System.Xml.XmlElement
- **CreateSketchConicBuilder(NXOpen.NXObject)** [Method]
  - System.Xml.XmlElement
- **CreateSketchChamferBuilder** [Method]
  - System.Xml.XmlElement
- **CreateAutoDimensionBuilder** [Method]
  - System.Xml.XmlElement
- **CreateSketchPatternBuilder(NXOpen.SketchPattern)** [Method]
  - System.Xml.XmlElement
- **CreateSketchMirrorPatternBuilder(NXOpen.SketchPattern)** [Method]
  - System.Xml.XmlElement
- **CreateMakeSymmetricBuilder** [Method]
  - System.Xml.XmlElement

---

# Feature Builders Reference

## ExtrudeBuilder

Represents a extrude feature builder.

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
- **Section**: Returns or sets the section
- **SmartVolumeProfile**: Returns the smart volume profile
- **SmartVolumeProfile1**: Returns the smart volume profile

## RevolveBuilder

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

## SweepAlongGuideBuilder

System.Xml.XmlElement

### Properties

- **BooleanOperation**: Returns the boolean operation
- **ChainingTolerance**: Returns or sets the chaining tolerance
- **DistanceTolerance**: Returns or sets the distance tolerance
- **FeatureOptions**: Returns the feature options
- **FirstOffset**: Returns the first offset
- **Guide**: Returns the guide
- **SecondOffset**: Returns the second offset
- **Section**: Returns the section

## ThroughCurvesBuilder

System.Xml.XmlElement

### Properties

- **Alignment**: Returns the alignment.
- **BodyPreference**: Returns or sets the body type options
- **ClosedInV**: Returns or sets the closed in V.
- **Construction**: Returns or sets the construction options.
- **CurvatureTolerance**: Returns or sets the curvature tolerance.
- **FirstSectionContinuity**: Returns the first section continuity.
- **FlowDirection**: Returns the flow direction.
- **LastSectionContinuity**: Returns the last section continuity.
- **LoftingSurfaceRebuildData**: Returns the lofting surface rebuild data.
- **NormalToEndSections**: Returns or sets the option of normal to end sections for Through Curves surface, which makes the output surface normal to the two end sections.
- **PatchType**: Returns or sets the patch type.
- **PositionTolerance**: Returns or sets the position tolerance.
- **PreserveShape**: Returns or sets the preserve shape.
- **SectionSurfaceRebuildData**: Returns the section surface rebuild data.
- **SectionTemplateString**: Returns or sets the section template curve.
- **SectionsList**: Returns the sections list which is required.
- **SplitOutputAlongBoundaryCurves**: Returns or sets the split output along boundary curves option
- **TangentTolerance**: Returns or sets the tangent tolerance.

## BooleanBuilder

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
- **Targets**: Returns the target bodies for the boolean operation
- **Tolerance**: Returns or sets the tolerance
- **Tolerance1**: Returns or sets the tolerance
- **Tool**: Returns or sets the tool body
- **ToolBodyCollector**: Returns or sets the tool body collector for the boolean operation
- **ToolBodyCollector1**: Returns or sets the tool body collector for the boolean operation
- **Tools**: Returns the tool bodies for the boolean operation for versions before 7.

## TrimBodyBuilder

Represents the trim body feature builder.

### Properties

- **Tool**: Returns or sets the tool of the trim body feature
- **TrimDirection**: Returns or sets the trim direction of the trim body feature

## SplitBodyBuilder

System.Xml.XmlElement

### Properties

- **BooleanTool**: Returns the tool bodies to split the target body(s).
- **KeepImprintedEdges**: Returns or sets the keep imprinted edges option
- **TargetBody**: Returns the target body to split.
- **TargetBodyCollector**: Returns or sets the collector of target bodies to split.
- **Tolerance**: Returns or sets the tolerance

## ChamferBuilder

Represents the chamfer builder data.

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
- **SecondOffsetExp**: Returns the second offset expression object of chamfer.
- **SmartCollector**: Returns or sets the smart collector
- **Tolerance**: Returns or sets the tolerance used for creating chamfer

## EdgeBlendBuilder

Represents a Edge Blend builder.

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
- **PatchComplexGeometryAreas**: Returns or sets the Patch Areas option
- **RemoveSelfIntersection**: Returns or sets the Remove self-intersection option
- **RollOntoEdge**: Returns or sets the Roll onto edges option
- **RollOverSmoothEdge**: Returns or sets the Roll over smooth edges option
- **SegmentBlendFaces**: Returns or sets the Segment blend to match face segments option
- **SetbackOption**: Returns or sets the setback option for edge blend
- **Tolerance**: Returns or sets the tolerance of a variable blend
- **TrimmingOption**: Returns or sets the trimming option
- **ZeroSlopeRadiusFunctionAtChainEnds**: Returns or sets the zero slope radius function at chain ends option

## ShellBuilder

Represents the Shell feature builder.

### Properties

- **Body**: Returns or sets the body to be shelled.
- **DefaultThickness**: Returns the default thickness for the shelled body.
- **DefaultThicknessFlip**: Returns or sets the flip direction option for default thickness.
- **FaceThicknessList**: Returns or sets the list of faces and corresponding alternate thickness for each.
- **FaceThicknesses**: Returns the list of faces and corresponding alternate thickness for each.
- **RemovedFacesCollector**: Returns or sets the set of faces to be removed from the shelled body.
- **TgtPierceOption**: Returns or sets the option to process tangent remove faces for the Shell operation.
- **Tolerance**: Returns or sets the tolerance for the Shell operation.
- **UseSurfaceApproximation**: Returns or sets the option to use approximate surfaces for the Shell operation.

## DraftBuilder

Represents a Draft Feature Builder that creates or edits a draft (Old name Taper) feature.

### Properties

- **AngleTolerance**: Returns or sets the angle tolerance in [rad/deg]
- **Direction**: Returns or sets the smart direction for draft
- **DistanceTolerance**: Returns or sets the distance tolerance in [in/mm]
- **DraftAllInstances**: Returns or sets the option "Draft all instances" [true/false]
- **DraftBothSides**: Returns or sets whether to draft on both sides of the reference
- **DraftIsoclineOrTruedraft**: Returns or sets the Draft method
- **DraftReferencesMethod**: Returns or sets the draft references method
- **EdgeSetAngleExpressionList**: Returns the list of draft edges SC Collectors and corresponding draft angles.
- **FaceSetAngleExpressionList**: Returns the list of draft faces SC Collectors and corresponding draft angles.
- **PartingReference**: Returns the parting reference as SC Collector containing only faces or only one datum plane or only one point.
- **StationaryEntity**: Returns or sets the stationary entity for draft.
- **StationaryPartingReference**: Returns the stationary parting reference as SC Collector containing only faces or only one datum plane or only one point Note that DraftBuilder.
- **StationaryReference**: Returns the stationary reference as SC Collector containing only faces or only one datum plane or only one point
- **SymmetricAngle**: Returns or sets whether draft angles on both sides of the parting reference are symmetric
- **TwoDimensionFaceSetsData**: Returns the list of draft faces SC Collectors and corresponding draft angles above and below the parting reference.
- **TypeOfDraft**: Returns or sets the Draft type
- **VariableAngleData**: Returns the Data object for Variable Angle Draft

## HoleFeatureBuilder

Represents a Hole feature builder.

### Properties

- **CounterboreDepth**: Returns the depth of the counterbore for a hole.
- **CounterboreDiameter**: Returns the diameter of the counterbore for a hole.
- **CountersinkAngle**: Returns the angle of the countersink for a hole.
- **CountersinkDiameter**: Returns the diameter of the countersink for a hole.
- **Depth**: Returns the depth of the hole.
- **Diameter**: Returns the diameter of the hole.
- **HoleLocation**: Returns or sets the reference point of the hole.
- **PlacementFace**: Returns or sets the placement face of the hole.
- **ReverseDirection**: Returns or sets the reverse direction flag of the hole.
- **Subtype**: Returns or sets the type of hole
- **TipAngle**: Returns the tip angle of the hole.

## ThreadBuilder

System.Xml.XmlElement

### Properties

- **Angle**: Returns the angle
- **AngleExp**: Returns the angle expression for manual thread
- **CylinderDiameter**: Returns the cylinder diameter
- **CylindricalFace**: Returns the cylindrical face
- **ExtendStart**: Returns or sets the extend start
- **HolePreference**: Returns or sets the hole preference
- **IsInternalThread**: Returns the thread internal or external flag
- **MajorDiameter**: Returns the major diameter
- **MajorDiameterExp**: Returns the major diameter expression for manual thread
- **MatchThreadSizeToCylinder**: Returns or sets the match thread size to cylinder
- **MinorDiameter**: Returns the minor diameter
- **MinorDiameterExp**: Returns the minor diameter expression for manual thread
- **NumStarts**: Returns or sets the num starts
- **Pitch**: Returns the pitch
- **PitchExp**: Returns the pitch expression for manual thread
- **PitchMultiple**: Returns the pitch multiple
- **RadialEngage**: Returns or sets the radial engage
- **ReverseThreadDirection**: Returns or sets the reverse thread direction
- **ShaftDiameter**: Returns the shaft diameter
- **ShaftDiameterExp**: Returns the shaft diameter expression

## PatternFeatureBuilder

System.Xml.XmlElement

### Properties

- **CreateReferencePattern**: Returns or sets the Create Reference Pattern option
- **ExpressionOption**: Returns or sets the expression transfer option
- **FeatureList**: Returns the Features
- **OutputOption**: Returns or sets the output option
- **PatternMethod**: Returns or sets the Pattern method
- **PatternService**: Returns the Pattern definition service
- **ReferencePoint**: Returns or sets the reference point
- **ReferencePointService**: Returns the reference point service
- **UseInferredReferencePoint**: Returns or sets a flag to indicate whether to use reference point inferred from selected feature(s) or not.

## MirrorFeatureBuilder

System.Xml.XmlElement

### Properties

- **FeatureSet**: Returns the Features
- **Plane**: Returns the Mirror Plane
- **PlaneConstructor**: Returns or sets the plane constructor
- **PlaneOption**: Returns or sets the plane option

## BlockFeatureBuilder

Represents a block feature builder.

### Properties

- **BooleanOption**: Returns the boolean option
- **BooleanType**: Returns or sets the boolean operation for the block
- **Height**: Returns the expression representing the block height.
- **Length**: Returns the expression representing the block length.
- **Origin**: Returns or sets the point coordinates representing the block origin.
- **OriginPoint**: Returns or sets the block origin point
- **ParentAssociativity**: Returns or sets the option to keep associativity of the Origin and Origin Offset Points
- **PointFromOrigin**: Returns or sets the point which defines values along the x, y axes of the WCS from origin point, when type is two point and height.
- **Target**: Returns or sets the target body for the boolean operation (if any) for the block
- **Type**: System.Xml.XmlElement
- **Width**: Returns the expression representing the block width.

## CylinderBuilder

System.Xml.XmlElement

### Properties

- **Arc**: Returns the arc
- **Axis**: Returns or sets the axis
- **BooleanOption**: Returns the boolean option
- **Diameter**: Returns the diameter.
- **Direction**: Returns or sets the cylinder direction
- **Height**: Returns the height
- **Origin**: Returns or sets the cylinder origin
- **ParentAssociativity**: Returns or sets the option to keep associativity of the cylinder axis
- **ReverseDirection**: Returns or sets the reverse direction
- **Type**: Returns or sets the type

## SphereBuilder

System.Xml.XmlElement

### Properties

- **Arc**: Returns the selected arc associated with the Sphere.
- **BooleanOption**: Returns the boolean operation associated with the Sphere.
- **CenterPoint**: Returns or sets the center point of the Sphere.
- **Diameter**: Returns the diameter of the Sphere.
- **ParentAssociativity**: Returns or sets the option to keep associativity of the sphere center point
- **Type**: System.Xml.XmlElement

## ConeBuilder

Represents a builder for a cone feature.

### Properties

- **Axis**: Returns or sets the axis
- **BaseArc**: Returns the base arc
- **BaseDiameter**: Returns the base diameter
- **BooleanOption**: Returns the boolean option
- **HalfAngle**: Returns the half angle
- **Height**: Returns the height
- **ParentAssociativity**: Returns or sets the option to keep associativity of the cone axis
- **TopArc**: Returns the top arc
- **TopDiameter**: Returns the top diameter
- **Type**: System.Xml.XmlElement

## TubeBuilder

System.Xml.XmlElement

### Properties

- **BooleanOption**: Returns the boolean option
- **InnerDiameter**: Returns the inner diameter
- **OuterDiameter**: Returns the outer diameter
- **OutputOption**: Returns or sets the output topology option
- **PathSection**: Returns the path section
- **Tolerance**: Returns or sets the distance tolerance

## OffsetSurfaceBuilder

This class represents a offset surface builder, used for creating or editing an offset surface feature.

### Properties

- **ApproxOption**: Returns or sets the option to create approximate offset surface if the offset surface has self-intersections.
- **FaceSets**: Returns the list of face sets.
- **MaximumExcludedObjects**: Returns or sets the maximum excluded objects during partial offset.
- **OutputOption**: System.Xml.XmlElement
- **PartialOption**: Returns or sets the option to pursue a partial offset result
- **Radius**: Returns the radius for error vertex excision during partial offset
- **RemoveProblemVerticesOption**: Returns or sets the option to remove problem vertices
- **StepOption**: Returns or sets the offset surface allow step boundaries option.
- **Tolerance**: Returns or sets the offset surface tolerance

## ThickenBuilder

System.Xml.XmlElement

### Properties

- **ApproximateOffset**: Returns or sets the "approximate offset surface" or "resolve self-intersections using patches" option.
- **BooleanOperation**: Returns the boolean operation.
- **FaceCollector**: Returns the faces to thicken.
- **FirstOffset**: Returns the first offset.
- **RegionSectionList**: Returns the list of SC_section The sections with corresponding expression for the Thicken feature
- **RegionToPierce**: Returns the section for regions to pierce The section associated for the Thicken feature
- **RemoveGashes**: Returns or sets the remove gashes option.
- **ReverseDirection**: Returns or sets the reverse direction.
- **SecondOffset**: Returns the second offset.
- **Tolerance**: Returns or sets the tolerance.

## ProjectCurveBuilder

System.Xml.XmlElement

### Properties

- **AngleToProjectionVector**: Returns the angle to projection vector
- **BridgedGapSize**: Returns or sets the maximum bridged gap size.
- **CurveFitData**: Returns the curve fit settings
- **CurveFitJoinData**: Returns the curve fit join method
- **EqualArcLengthMethod**: Returns or sets the equal arc length method
- **FaceToProjectTo**: Returns the face to project to
- **GapOption**: Returns or sets the gap option whether to create curve to bridge gap or not
- **InputCurvesOption**: Returns the input curves option
- **LineToProjectToward**: Returns the line to project toward
- **NearestPointOption**: Returns or sets the nearest point option whether to project curve by nearest point or not.
- **PlaneToProjectTo**: Returns or sets the plane to project to
- **PointToProjectToward**: Returns or sets the point to project toward
- **ProjectionDirectionMethod**: Returns or sets the projection direction method
- **ProjectionOption**: Returns or sets the projection option type
- **ProjectionVector**: Returns or sets the projection vector
- **ReferencePointForEqualArcLength**: Returns or sets the reference point for equal arc length
- **SectionToProject**: Returns the section to project
- **Tolerance**: Returns or sets the tolerance
- **XVectorForEqualArcLength**: Returns or sets the x vector for equal arc length

## IntersectionCurveBuilder

System.Xml.XmlElement

### Properties

- **Associative**: Returns or sets the associative
- **CurveFitData**: Returns the curve fit settings
- **CurveFitOptions**: Returns the curve fit options
- **FirstFace**: Returns the first face
- **FirstPlane**: Returns or sets the first plane
- **FirstSet**: Returns the first set required only for non-associative intersection curve
- **SecondFace**: Returns the second face
- **SecondPlane**: Returns or sets the second plane
- **SecondSet**: Returns the second set required only for non-associative intersection curve
- **Tolerance**: Returns or sets the tolerance

## BridgeCurveBuilder

System.Xml.XmlElement

### Properties

- **ConstraintFaces**: Returns the constraint faces
- **CurveFitData**: Returns the curve fitting parameters
- **CurveFitOption**: Returns or sets the curve fit option
- **Depth**: System.Xml.XmlElement
- **EndContinuityOption**: Returns or sets the end continuity option
- **EndCurveDirectionOption**: Returns or sets the end curve direction option
- **EndDirectionAngle**: Returns the end direction angle
- **EndObject**: Returns the end object
- **EndObjectOption**: Returns or sets the object selection option
- **EndPerpendicularFace**: Returns the end perpendicular face
- **EndPointDirection**: Returns or sets the end point direction
- **EndReferencePoint**: Returns or sets the start reference point
- **EndSurfaceDirectionOption**: Returns or sets the end surface direction option
- **EndTangentMagnitude**: System.Xml.XmlElement
- **EndVectorObject**: Returns or sets the start point direction
- **IsAssociative**: Returns or sets whether the bridge curve is associative
- **MaximumDegree**: Returns or sets the maximum degree
- **MaximumSegment**: Returns or sets the maximum segment
- **MinimumRadiusOption**: Returns or sets the minimum radius option
- **MinimumRadiusValue**: Returns the minimum radius value

## CompositeCurveBuilder

System.Xml.XmlElement

### Properties

- **AllowSelfIntersection**: Returns or sets the self intersection
- **Associative**: Returns or sets the associative
- **CurveFitData**: Returns the curve fit data
- **FixAtCurrentTimestamp**: Returns or sets the fix at timestamp option
- **FrecAtTimeStamp**: Returns or sets the frec at time stamp
- **HideOriginal**: Returns or sets the hide original
- **InheritDisplayProperties**: Returns or sets the inherit display properties from source option
- **InputCurvesOption**: Returns or sets the input curve options
- **JoinOption**: Returns or sets the join option
- **MakePositionIndependent**: Returns or sets the make position independent
- **ParentPart**: Returns or sets the parent part
- **ReverseDirection**: Returns or sets the composite curve reverse direction
- **Section**: Returns the section
- **SourcePartOccurrence**: Returns or sets the source part occurrence
- **Tolerance**: Returns or sets the tolerance

## DatumPlaneBuilder

Represents a datum plane feature builder.

### Properties

- **OffsetInstance**: Returns or sets the offset instance plane flag
- **ResizeDuringUpdate**: Returns or sets the resize during update

## DatumAxisBuilder

Represents a datum axis feature builder.

### Properties

- **AlternateSolutionType**: Returns or sets the alternate solution type.
- **ArcLength**: Returns the arc length.
- **Curve**: Returns the curve or edge.
- **CurveOrFace**: Returns the curve or face .
- **CurveOrientation**: Returns or sets the orientation of vector on a curve.
- **DirectionOrientation**: Returns or sets the direction orientation.
- **IsAssociative**: Returns or sets the associativity.
- **IsAxisReversed**: Returns or sets the datum axis direction.
- **Object1**: Returns the first object (i.
- **Object2**: Returns the second object (i.
- **Objects**: Returns the objects to define Datum Axis.
- **OrientationObject**: Returns the orientation object.
- **Point**: Returns or sets the point.
- **Point1**: Returns or sets the first point.
- **Point2**: Returns or sets the second point.
- **ResizedEndDistance**: Returns or sets the resized distance for the end point.
- **ReverseDirection**: Returns or sets
- **Section**: Returns the section.
- **Type**: Returns or sets the Datum Axis type
- **Vector**: Returns or sets the vector.

## DatumCsysBuilder

Represents a datum csys builder

### Properties

- **ComponentsCreation**: Returns or sets the flag of the Datum Csys components creation
- **Csys**: Returns or sets the CSYS that defines a Datum CSYS
- **DisplayScaleFactor**: Returns or sets the scale factor of the input Datum Csys
- **FixedSizeDatum**: Returns or sets the fixed size flag of a created Datum Csys

