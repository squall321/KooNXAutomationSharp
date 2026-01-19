# NXOpen API Reference
Total Types: 17308

## Namespaces (112)
- NXOpen (1176 types)
- NXOpen.AECDesign (15 types)
- NXOpen.ALPTest (1 types)
- NXOpen.Annotations (960 types)
- NXOpen.Appearance (15 types)
- NXOpen.Assemblies (173 types)
- NXOpen.Assemblies.ProductInterface (9 types)
- NXOpen.AutomatedTesting (5 types)
- NXOpen.BodyDes (12 types)
- NXOpen.CableRouter (18 types)
- NXOpen.CableRouter.Managed (45 types)
- NXOpen.CADCAEPrep (19 types)
- NXOpen.CAE (2417 types)
- NXOpen.CAE.AeroStructures (93 types)
- NXOpen.CAE.AeroStructures.Author (31 types)
- NXOpen.CAE.Connections (164 types)
- NXOpen.CAE.ContactPreview (4 types)
- NXOpen.CAE.FTK (25 types)
- NXOpen.CAE.Magnet (12 types)
- NXOpen.CAE.MeshMapping (1 types)
- NXOpen.CAE.ModelCheck (52 types)
- NXOpen.CAE.ModelDependencyCheck (2 types)
- NXOpen.CAE.Optimization (19 types)
- NXOpen.CAE.PenetrationCheck (16 types)
- NXOpen.CAE.PostProc (16 types)
- NXOpen.CAE.QualityAudit (67 types)
- NXOpen.CAE.ResponseSimulation (156 types)
- NXOpen.CAE.RotorDynamics (6 types)
- NXOpen.CAE.Safety (1 types)
- NXOpen.CAE.Xyplot (164 types)
- NXOpen.CAM (1889 types)
- NXOpen.CAM.FBM (11 types)
- NXOpen.CLDCommon (3 types)
- NXOpen.CloudDM (19 types)
- NXOpen.CollaborationApplication (12 types)
- NXOpen.DesignSimulation (99 types)
- NXOpen.Diagramming (107 types)
- NXOpen.Diagramming.Geometry (15 types)
- NXOpen.Diagramming.Tables (24 types)
- NXOpen.DiagrammingLibraryAuthor (19 types)
- NXOpen.Die (184 types)
- NXOpen.Display (295 types)
- NXOpen.Drafting (24 types)
- NXOpen.Drawings (343 types)
- NXOpen.ElectricalRouting (11 types)
- NXOpen.Facet (108 types)
- NXOpen.Features (1490 types)
- NXOpen.Features.AECDesign (131 types)
- NXOpen.Features.DrawShapes (30 types)
- NXOpen.Features.Industry (5 types)
- NXOpen.Features.SheetMetal (217 types)
- NXOpen.Features.ShipDesign (593 types)
- NXOpen.Features.ShipDesign.GeneralArrangement (8 types)
- NXOpen.Features.StructureDesign (125 types)
- NXOpen.Features.Subdivision (94 types)
- NXOpen.Features.VehicleDesign (345 types)
- NXOpen.Fields (100 types)
- NXOpen.Formboard (25 types)
- NXOpen.Gateway (40 types)
- NXOpen.GCTools (5 types)
- NXOpen.GeometricAnalysis (148 types)
- NXOpen.GeometricAnalysis.SectionAnalysis (27 types)
- NXOpen.GeometricUtilities (381 types)
- NXOpen.GeometricUtilities.UVMapping (12 types)
- NXOpen.Implicit (67 types)
- NXOpen.InfoWindow (6 types)
- NXOpen.Issue (19 types)
- NXOpen.Layer (7 types)
- NXOpen.Layout2d (45 types)
- NXOpen.Markup (21 types)
- NXOpen.MBD (1 types)
- NXOpen.MechanicalRouting (72 types)
- NXOpen.Mechatronics (733 types)
- NXOpen.MendixReporting (4 types)
- NXOpen.MigrationManager (1 types)
- NXOpen.ModlDirect (1 types)
- NXOpen.ModlUtils (12 types)
- NXOpen.Motion (691 types)
- NXOpen.OpenXml (10 types)
- NXOpen.Optimization (21 types)
- NXOpen.Options (7 types)
- NXOpen.PartFamily (8 types)
- NXOpen.PcbExchange (133 types)
- NXOpen.PDM (178 types)
- NXOpen.PDM.SaveManagement (4 types)
- NXOpen.PhysMat (7 types)
- NXOpen.Placement (2 types)
- NXOpen.PLAS (5 types)
- NXOpen.Positioning (25 types)
- NXOpen.Preferences (352 types)
- NXOpen.RegionRecognition (16 types)
- NXOpen.Report (35 types)
- NXOpen.Routing (397 types)
- NXOpen.Routing.Electrical (56 types)
- NXOpen.RoutingCommon (89 types)
- NXOpen.Schematic (53 types)
- NXOpen.Schematic.Mechanical (9 types)
- NXOpen.Schematic.Model (4 types)
- NXOpen.ShapeSearch (6 types)
- NXOpen.SheetMetal (4 types)
- NXOpen.ShipDesign (32 types)
- NXOpen.SIM (102 types)
- NXOpen.SIM.PostConfigurator (37 types)
- NXOpen.StructureDesign (13 types)
- NXOpen.Sustainability (5 types)
- NXOpen.Tooling (906 types)
- NXOpen.UserDefinedObjects (32 types)
- NXOpen.UserDefinedTemplate (86 types)
- NXOpen.Validate (88 types)
- NXOpen.Validate.Corrosion (9 types)
- NXOpen.VisualReporting (38 types)
- NXOpen.Weld (226 types)

## Core Classes (NXOpen namespace)

### Session
Base: BaseSession
**Properties:**
- AfuManager: AfuManager
- DexManager: DexManager
- PvtransManager: PvtransManager
- FTKManager: FTKManager
- Post: Post
- ResultManager: ResultManager
- CaeSession: CaeSession
- UpdateManager: Update
- Parts: PartCollection
- WeldCustomManager: CustomManager
- ValidationManager: ValidationManager
- CheckerDataStatus: CheckerDataStatus
- AutomatedTestingManager: TestingManager
- ListingWindow: ListingWindow
- SpreadsheetManager: SpreadsheetManager
- DisplayManager: DisplayManager
- MathUtils: MathUtils
- EngineeringFunction: EngineeringFunction
- Measurement: Measurement
- Information: Information
**Methods:**
- GetMinimallyLoadedParts(BasePart[]& minimallyLoadedParts): Void
- GetTranslatedString(String fileName, String uniqueID, String stringToTranslate, String context): String
- IsFunctionalRelease(): Boolean
- CreateRoutingSession(): Void
- CreateMechanicalRoutingSession(): Void
- GetCustomerDefaultValue(String defaultName, CustomerDefaultSearchOption customerDefaultSearchOption, String& defaultValue): Boolean
- IsInspectionSessionInitialized(): Boolean
- GetProperty(TaggedObject object, String propertyName): String
- SetProperty(TaggedObject object, String propertyName, String value): Void
- GetNamedProperties(TaggedObject object): String[]
- GetClasses(): String[]
- GetNamedProperties(String className, String[]& properties, String[]& propertyTypes): Void
- CleanUpFacetedFacesAndEdges(): Void
- AssignRemoveProjects(String[] cliNames, ProjectAssignmentObjectType[] objectTypes, String[] projectNames, ProjectAssignmentState[] assignmentStates): Void
- GetEnvironmentVariableValue(String envVaribable): String
- SetEnvironmentVariableValue(String envVaribable, String envValue): Void
- EnableRedo(Boolean enableRedo): Boolean
- NewTransientText(): TransientText
- AssignRemoveProjectsBasedOnPartOccs(TaggedObject[] partOccs, ProjectAssignmentObjectType[] objectTypes, String[] projectNames, ProjectAssignmentState[] assignmentStates): Void
- ApplicationSwitchOnActiveDisplayedPart(): Void

### Part
Base: BasePart
**Properties:**
- Bodies: BodyCollection
- CutViews: CutViewCollection
- Dimensions: DimensionCollection
- DraftingViews: DraftingViewCollection
- DrawingSheets: DrawingSheetCollection
- DraftingDrawingSheets: DraftingDrawingSheetCollection
- Notes: NoteCollection
- Labels: LabelCollection
- Gdts: GdtCollection
- Markers: MarkerCollection
- RouteManager: RouteManager
- SegmentManager: SegmentManager
- MechanicalRoutingCollectionsManager: CollectionsManager
- ElectricalRoutingCollectionsManager: CollectionsManager
- Sketches: SketchCollection
- Tracelines: TracelineCollection
- FaceSetOffsets: FaceSetOffsetCollection
- PackagingCollection: PackagingCollection
- MotionManager: MotionManager
- PhysicsManager: PhysicsManager
**Methods:**
- CreateSelectionList(): SelectionList
- CreateEmptySelectionList(): SelectionList
- CreatePointsFromFileBuilder(): PointsFromFileBuilder
- ConvertPreNX9CompoundWelds(): Void
- RemoveMissingParentsFromEdgeBlend(Int32[]& removedEdgeCounts): EdgeBlend[]
- NewPartFamilyTemplateManager(): TemplateManager
- GetFamilyInstance(): Instance
- CreateEmptyBlendSetbackBuilder(): BlendSetbackBuilder
- CreateEmptyTransitionCurveBuilder(): TransitionCurveBuilder
- CreateEmptySpinePlaneBuilder(): SpinePlaneBuilder
- LoadWaveLinkFeatureParents(): PartLoadStatus
- CreateImportTemplatePartBuilder(ImportTemplatePart importtemplatePart): ImportTemplatePartBuilder
- UpdateFromJtFile(String jtFilePath, UpdateFromJtFileOptions updateOption): Void
- RefreshPartitionData(): Void
- CreateEmptyExpressionSectionSet(): ExpressionSectionSet
- CreateEmptyTwoExpressionsSectionSet(): TwoExpressionsSectionSet
- CreateExpressionCollectorSet(ScCollector collector, String value, String unitsType, Int32 index): ExpressionCollectorSet
- CreateTwoExpressionsCollectorSet(ScCollector collector, String value, String valueTwo, String unitsType, Int32 index): TwoExpressionsCollectorSet
- CreateEmptyExpressionCollectorSet(): ExpressionCollectorSet
- CreateEmptyTwoExpressionsCollectorSet(): TwoExpressionsCollectorSet

### BasePart
Base: NXObject
**Properties:**
- CgfxAttrs: CgfxAttrCollection
- CgfxMattex: CgfxMattexCollection
- WCS: WCS
- Arcs: ArcCollection
- Parabolas: ParabolaCollection
- AnalysisManager: AnalysisManager
- MeasureManager: MeasureManager
- Layers: LayerManager
- Xforms: XformCollection
- Offsets: OffsetCollection
- Planes: PlaneCollection
- Hyperbolas: HyperbolaCollection
- Curves: CurveCollection
- Points: PointCollection
- Ellipses: EllipseCollection
- Lines: LineCollection
- InfiniteLines: InfiniteLineCollection
- Splines: SplineCollection
- Polylines: PolylineCollection
- NXMatrices: NXMatrixCollection
**Methods:**
- CreateReferenceSet(): ReferenceSet
- DeleteReferenceSet(ReferenceSet referenceSetObject): Void
- GetAllReferenceSets(): ReferenceSet[]
- GetMakeUniqueName(): String
- SetMakeUniqueName(String newUniqueName): Void
- CreateEffectivityConditionBuilder(CollaborativeDesign cd, String effectivityFormula): EffectivityConditionBuilder
- CreateEffectivityConditionBuilder(CollaborativeDesign cd, String validationBasisFormula, String effectivityFormula): EffectivityConditionBuilder
- GetCollaborativeContentType(): CollaborativeContentType
- CanBeDisplayPart(): Boolean
- Undisplay(): Void
- GetArrangements(Arrangement[]& arrangements): Void
- HasAnyMinimallyLoadedChildren(): Boolean
- GetMinimallyLoadedParts(BasePart[]& minimallyLoadedParts): Void
- DeleteDisplayFacets(Boolean deleteSavedDisplayFacets, Boolean processChildren): Void
- GetConfiguredParts(): ConfiguredPart[]
- CloseAllConfigurations(CloseWholeTree wholeTree, CloseModified closeModified, PartCloseResponses responses): Void
- CloseRetainUndoMarks(CloseWholeTree wholeTree, CloseModified closeModified, PartCloseResponses responses): Void
- LoadFully(): PartLoadStatus
- LoadThisPartFully(): PartLoadStatus
- LoadThisPartPartially(): PartLoadStatus

### Body
Base: DisplayableObject
**Properties:**
- Density: Double
- IsConvergentBody: Boolean
- IsSheetBody: Boolean
- IsSolidBody: Boolean
**Methods:**
- GetFeatures(): Feature[]
- GetFaces(): Face[]
- GetEdges(): Edge[]
- RemoveMergedRibImprintedEdges(Face originalFace, Edge[] imprintedEdges): Void
- GetFacetedBody(FacetedBody& facetBody, Boolean& upToDate): Void
- SweepabilityCheck(): Int32
- GetNumberOfFacets(): Int32
- GetNumberOfVertices(): Int32
- GetNextFacet(ConvergentFacet facet): ConvergentFacet
- GetFirstFacetOnBody(): ConvergentFacet

### Face
Base: DisplayableObject
**Properties:**
- SolidFaceType: FaceType
**Methods:**
- GetEdges(): Edge[]
- GetUnsortedEdges(): Edge[]
- GetBody(): Body
- GetNumberOfFacets(): Int32
- GetNumberOfVertices(): Int32
- GetNextFacet(ConvergentFacet inputFacet): ConvergentFacet
- GetFirstFacetOnFace(): ConvergentFacet
- DestroyOwnedFacets(): Void
- GetChamferData(ChamferType& chamferType, Double[]& offsets): Boolean
- GetBlendData(Double& radius, Boolean& isBlendFace): Void
- GetHoleData(Boolean& isHoleFace): ResizeHoleData

### Edge
Base: DisplayableObject
**Properties:**
- SolidEdgeType: EdgeType
- IsReference: Boolean
**Methods:**
- GetFaces(): Face[]
- GetUnsortedFaces(): Face[]
- GetVertices(Point3d& vertex1, Point3d& vertex2): Void
- GetBody(): Body
- GetDraftingCurveInfo(): DraftingCurveInfo
- IsDraftingCurve(): Boolean
- GetLength(): Double
- GetLocations(): CurveLocation[]

### Point
Base: SmartObject
**Properties:**
- Coordinates: Point3d
- IsReference: Boolean
**Methods:**
- SetCoordinates(Point3d coordinates): Void
- SetPointOnCurveTParameterFixed(Boolean isFixed): Void

### Curve
Base: SmartObject
**Properties:**
- IsReference: Boolean
**Methods:**
- GetDraftingCurveInfo(): DraftingCurveInfo
- IsDraftingCurve(): Boolean
- GetLength(): Double
- GetLocations(): CurveLocation[]

### Line
Base: Curve
**Properties:**
- EndPoint: Point3d
- StartPoint: Point3d
**Methods:**
- SetStartPoint(Point3d startPoint): Void
- SetEndPoint(Point3d endPoint): Void
- SetEndpoints(Point3d startPoint, Point3d endPoint): Void

### Arc
Base: Conic
**Properties:**
- EndAngle: Double
- Radius: Double
- StartAngle: Double
**Methods:**
- SetRadius(Double radius): Void
- SetParameters(Double radius, Point3d center, Double startAngle, Double endAngle, NXMatrix matrix): Void
- SetParameters(Double radius, Point3d center, Double startAngle, Double endAngle): Void

### Spline
Base: Curve
**Properties:**
- Order: Int32
- Periodic: Boolean
- PoleCount: Int32
- Rational: Boolean
**Methods:**
- GetKnots(): Double[]
- GetPoles(): Point4d[]
- Get3DPoles(): Point3d[]
- GetDefiningPoints(): Point3d[]

### NXObject
Base: TaggedObject
**Properties:**
- IsOccurrence: Boolean
- JournalIdentifier: String
- Name: String
- OwningComponent: Component
- OwningPart: BasePart
- Prototype: INXObject
**Methods:**
- SetAttribute(String title): Void
- SetAttribute(String title, Option option): Void
- SetTimeAttribute(String title, String value): Void
- SetTimeAttribute(String title, String value, Option option): Void
- GetIntegerAttribute(String title): Int32
- GetRealAttribute(String title): Double
- GetStringAttribute(String title): String
- GetTimeAttribute(DateAndTimeFormat format, String title): String
- GetReferenceAttribute(String title): String
- DeleteAttributeByTypeAndTitle(AttributeType type, String title): Void
- DeleteAttributeByTypeAndTitle(AttributeType type, String title, Option option): Void
- SetReferenceAttribute(String title, String value): Void
- SetReferenceAttribute(String title, String value, Option option): Void
- GetAttributeTitlesByType(AttributeType type): AttributeInformation[]
- GetUserAttributesAsStrings(): String[]
- FindObject(String journalIdentifier): INXObject
- Print(): Void
- SetName(String name): Void
- GetTimeUserAttribute(String title, Int32 index): String
- GetComputationalTimeUserAttribute(String title, Int32 index): ComputationalTime

### Builder
Base: TaggedObject
**Properties:**
- PreviewBuilder: PreviewBuilder
**Methods:**
- Commit(): NXObject
- Destroy(): Void
- GetCommittedObjects(): NXObject[]
- GetObject(): NXObject
- ShowResults(): Void
- Validate(): Boolean

### Expression
Base: NXObject
**Properties:**
- BooleanValue: Boolean
- Description: String
- Equation: String
- ExpressionString: String
- IntegerValue: Int32
- IsGeometricExpression: Boolean
- IsInterpartExpression: Boolean
- IsMassManagementExp: Boolean
- IsMeasurementExpression: Boolean
- IsNoEdit: Boolean
- IsNoUpdate: Boolean
- IsRightHandSideLockedFromEdit: Boolean
- IsTrulyUnitless: Boolean
- IsUserLocked: Boolean
- IsUserSpecified: Boolean
- IsVisible: Boolean
- NumberValue: Double
- PointValue: Point3d
- RightHandSide: String
- Status: StatusOption
**Methods:**
- GetReferencingAttribute(AttributeSourceType attributeSourceType, AttributeInformation& info): Boolean
- GetReferencingPartOrObjectAttribute(AttributeSourceType& attributeSourceType, AttributeInformation& info): Boolean
- GetFormulaDescription(): String
- GetFormula(): String
- SetFormula(String rightHandSide): Void
- SetNumberValueWithUnits(Double numberValue, Unit units): Void
- GetNumberValueWithUnits(UnitsOption unitsOption, Double& numberValue, Unit& unit): Void
- GetPointValueWithUnits(UnitsOption unitsOption): Point3d
- GetVectorValueWithUnits(UnitsOption unitsOption): Vector3d
- GetListValue(): Object
- GetPersistentlyLocked(): Boolean
- SetPersistentlyLocked(Boolean isLocked): Void
- EditComment(String newComment): Void
- GetUsingFeatures(): Feature[]
- GetOwningFeature(): Feature
- GetOwningRpoFeature(): Feature
- GetDescriptor(): String
- GetReferencingExpressions(): Expression[]
- GetInterpartExpressionNames(String& partName, String& expName): Void
- GetValueUsingUnits(UnitsOption unitsOption): Double

### CoordinateSystem
Base: SmartObject
**Properties:**
- IsTemporary: Boolean
- Label: Int32
- Name: String
- Orientation: NXMatrix
- Origin: Point3d
**Methods:**
- GetDirections(Vector3d& xDirection, Vector3d& yDirection): Void
- SetDirections(Vector3d xDirection, Vector3d yDirection): Void
- GetSolverCardSyntax(): String[]

### CartesianCoordinateSystem
Base: CoordinateSystem

### Matrix3x3
Base: ValueType
**Methods:**
- ToString(): String

### Point3d
Base: ValueType
**Methods:**
- ToString(): String

### Vector3d
Base: ValueType
**Methods:**
- ToString(): String

## Features (NXOpen.Features)

- AdaptiveShellBuilder
- ADASCoordinateSystemBuilder
- AdmBaseBuilder
- AdmMoveFaceBuilder
- AdmOffsetRegionBuilder
- AdmResizeFaceBuilder
- AeroFlangeBuilder
- AeroRibBuilder
- AestheticFaceBlendBuilder
- AlgorithmicFeatureBuilder
- AnalyzePocketBuilder
- AngularDimBuilder
- AOCSBuilder
- ApexRangeChamferBuilder
- AssemblyCutBuilder
- AssociativeArcBuilder
- AssociativeLineBuilder
- BevelGearBuilder
- BlendCornerBuilder
- BlendCurveOnSurfaceBuilder
- BlendPocketBuilder
- BlockFeatureBuilder
- BodyByEquationBuilder
- BodyLattice2Builder
- BodyLatticeBuilder
- BooleanBuilder
- BoundedPlaneBuilder
- BridgeCurveBuilder
- BridgeSurfaceBuilder
- CenterlineBuilder
