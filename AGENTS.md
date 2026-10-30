#   Utils package instructions

Read [architecture][architecture] before dependency or public API changes, [usage][usage] before consumer changes, and the [serialization decision][serialization] before changing malformed-data behavior.

*   Utils owns technical helpers, not application contracts or domain outcomes. Preserve public signatures, serialized names, existing exception behavior and asset GUIDs unless the migration is explicitly agreed.
*   Mathematics is a direct runtime dependency because Duo types expose math-vector conversions. uGUI is required by Graphic extensions. TMP and Cinemachine are not direct dependencies. Existing ENABLED_UNITY_MATHEMATICS branches remain caller-controlled; do not auto-enable them as a side effect of installation.
*   Dictionary keys/values backing lists are serialized data. On mismatched counts, log the existing error and leave the runtime dictionary empty. Preserve matching-data round trips and existing duplicate/null-key semantics. Drawer changes must reserve child heights and restore GUI state.
*   Keep Editor code in the Editor assembly or existing UNITY_EDITOR guards. Validate actual PropertyDrawers in the Editor and runtime code in a minimal Player consumer; host package combinations can hide missing dependencies.
*   Run SWeetJelly.Utils.Tests.EditMode and SWeetJelly.Utils.Tests.PlayMode separately. Record exact Editor patch, platform, counts and fresh reports. Before release, validate manifest, root LICENSE, dependency/asmdef agreement, Git contents, metadata/GUID and migration docs. Public HTTPS Git-tag installation is a separate check after the user publishes the tag.
*   PRs, commits, pushes, tags, Releases and game-consumer updates belong to the user. Shared coordination follows the development host's installed unity-package harness. Keep package-specific architecture and decisions in this repository.

[architecture]: ARCHITECTURE.md
[usage]: README.md
[serialization]: docs/adr/0001-dependencies-and-malformed-serialization.md
