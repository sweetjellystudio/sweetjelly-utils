# SWeetJelly Utilities

Small runtime and editor utilities for Unity projects.

This package is intentionally limited to technical convenience helpers: extension methods, small utility classes, serializable helper types, and editor drawers. It should stay free of application contracts, domain decisions, and shared architectural language.

## Responsibility

Use this package for helpers that do not define what the application means by success, failure, policy, ownership, or lifecycle.

Good fits:

- Collection, string, number, vector, transform, and Unity object extensions
- Small Unity helpers for cameras, renderers, textures, layer masks, resources, and time
- Generic utility helpers such as enum, random, reflection, IO, and vector utilities
- Lightweight serializable helper types such as `SerializableDictionary`, `DuoTypes`, and `ToggleTypes`
- Editor-only drawers for the helper types above

Not a good fit:

- `Result`, `Error`, `Verdict`, or other shared contract models
- Package-specific error codes or block reasons
- Domain policies, application service contracts, save/load/loading outcomes, or business rules
- Anything that makes another package depend on Utils for architectural language

Those belong in a shared/foundation package or in the package that owns the concrete meaning.

## Assemblies

- `SWeetJelly.Utils`
- `SWeetJelly.Utils.Editor`

The runtime assembly is auto-referenced and uses the root namespace `SWeetJelly`.

## Runtime Contents

### Extensions

Includes extension methods for common .NET and Unity types:

- `ArrayAndListExtensions`
- `DictionaryExtensions`
- `EnumerableExtensions`
- `StringExtensions`
- `NumberExtensions`
- `MathfExtensions`
- `Vector2Extensions`
- `Vector3Extensions`
- `VectorConversionExtensions`
- `TransformExtensions`
- `GameObjectExtensions`
- `ObjectExtensions`
- `CameraExtensions`
- `RendererExtensions`
- `TextureExtensions`
- `ColorExtensions`
- `LayerMaskExtensions`
- `AsyncOperationExtensions`
- `TaskExtensions`

Example:

```csharp
using SWeetJelly;

if (items.IsNullOrEmpty())
{
    return;
}

playerTransform.ResetLocal();
```

### Utilities

Includes small static helpers:

- `EnumUtils`
- `IOUtils`
- `RandomUtils`
- `ReflectionUtils`
- `ResourcesUtils`
- `RuntimeEditorUtils`
- `TimeUtils`
- `VectorUtils`

Example:

```csharp
using SWeetJelly;

bool selected = RandomUtils.TrueFalse();
```

### Extras

Includes lightweight helper types and components:

- `SerializableDictionary`
- `Bezier`
- `DelayedObjectDisabler`
- `DuoTypes`
- `FPSCounter`
- `PhysicsHelper`
- `ToggleTypes`

## Editor Contents

The editor assembly provides drawers for utility helper types:

- `SerializableDictionaryDrawer`
- `DuoTypesPropertyDrawer`
- `ToggleTypesPropertyDrawer`

## Package Boundary

`Utils` should be easy for feature packages to reference because it does not own shared policy or result semantics.

For example:

```text
Loading -> Utils
Save -> Utils
Serialization -> Utils
```

But shared outcome models should flow from foundation/shared packages instead:

```text
Save -> Shared.Result
Loading -> Shared.Result
Serialization -> Shared.Result
```

In short:

```text
Utils = technical convenience helpers
Shared/Foundation = meaningful common contracts
Feature package = concrete errors, reasons, and policies
```
