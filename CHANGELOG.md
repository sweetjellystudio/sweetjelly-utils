# CHANGE LOG

## v2.0.0 (unreleased)

*   [Changed] Minimum supported Unity is 6.3 LTS.
*   [Changed] Declare Mathematics 1.3.3 and uGUI 2.0.0; remove unused Cinemachine/TMP dependencies and TMP assembly reference.
*   [Fixed] Malformed dictionary list lengths log an error and produce an empty dictionary without an index exception.
*   [Fixed] Dictionary drawer reserves expanded row height and restores GUI indentation.
*   [Changed] Reflection injection uses the supported Unity object search API while preserving inactive-object inclusion.
*   [Added] Contract/runtime regression tests and maintained package guidance.

This is a local candidate; publication is a separate user action.

## v1.1.0

- [Fixed] : Fixed `SubArray` to return items from the requested start index.
- [Fixed] : Fixed `TryGetChild` to return an existing child and null for invalid indices.
- [Added] : Added VectorUtils
- [Changed] : Expanded README with package responsibility, contents, examples, and boundary guidance.
- [Changed] : Clarified package description.
- [Changed] : Fixed trivial errors in Vector2, Vector3 extensions

## v1.0.0

- basic logic
