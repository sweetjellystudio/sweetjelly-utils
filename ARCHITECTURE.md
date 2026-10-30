#   Utils architecture

Utils supplies small technical extensions, utility functions, serializable helper types and their Editor drawers. It does not define result/policy semantics or application services. Existing namespaces and two assemblies remain; the migration does not introduce a new layer hierarchy. See [usage][usage] and the [decision][decision].

##  Dependencies and boundaries

SWeetJelly.Utils contains runtime helpers and editor-only paths guarded by UNITY_EDITOR. SWeetJelly.Utils.Editor contains the IMGUI PropertyDrawers and is restricted to Editor. Runtime directly references Unity.Mathematics and UnityEngine.UI. Mathematics conversions are part of Duo's public surface; ColorExtensions exposes Graphic. TMP and Cinemachine have no source usage and are removed from direct dependencies. Consumers needing those packages install them explicitly rather than relying on Utils to pull them in.

Some Mathf/Number APIs are guarded by ENABLED_UNITY_MATHEMATICS. This historical caller-controlled symbol is preserved, even though Duo requires Mathematics unconditionally. Installing the package does not turn the symbol on. Moving these APIs or changing the conditional surface is a separate design change.

##  Serialization and Editor behavior

SerializableDictionary stores keys and values in serialized backing lists and rebuilds the dictionary after deserialization. Matching lists preserve entries; duplicate keys retain the existing last-assignment behavior. Null-key behavior is inherited from Dictionary and is not redesigned. Mismatched lengths log the existing diagnostic and produce an empty runtime dictionary without indexing invalid data. The lists remain available to inspect; a subsequent serialization reflects the current dictionary state.

The dictionary drawer reserves a foldout line, per-row child heights and an Add button, preserving indent level on every exit. Malformed parallel lists display an error instead of drawing invalid array indices. Duo/Toggle drawers retain their current serialized field names and presentation system. Serialized assets and types are not migrated to new wrappers.

##  Runtime and ownership

Task.AsCoroutine waits for completion and propagates task failures/cancellation. Forget remains async void: an explicit handler receives exceptions; without one it propagates on the captured synchronization context as before. AsyncOperation.AsTask adds no cancellation API and observes the operation's completed event. DelayedObjectDisabler uses Unity coroutine timing and GameObject enable/disable lifecycle. Helpers do not establish a global service owner or dispose consumer resources.

Unity object, scene, UI and coroutine helpers follow Unity lifecycle/main-thread constraints; pure collection/math helpers do not make mutable payloads thread-safe. Version 2.0.0 changes the minimum Editor to 6.3 LTS, fixes the confirmed dictionary/Drawer failures and corrects dependencies while preserving other helper contracts.

##  Verification

Package EditMode tests cover existing helpers, dictionary round trips and malformed lengths, Duo conversion, Toggle behavior, Task propagation and actual Drawer GUI state. PlayMode covers pending/completed AsyncOperation, handler-based Forget, component re-enabling and Graphic alpha. The development host checks combination compilation; a minimal consumer resolves only Utils, its declared dependencies and test tools and builds a Windows Player. The Inspector is observed separately. These focused checks do not claim exhaustive validation of every helper, platform or backend.

[usage]: README.md
[decision]: docs/adr/0001-dependencies-and-malformed-serialization.md
