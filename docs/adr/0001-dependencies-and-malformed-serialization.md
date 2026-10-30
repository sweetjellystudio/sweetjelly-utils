#   Direct dependencies and malformed dictionary data

Accepted 2026-10-30 for 2.0.0. Preserve Duo's Mathematics conversions and Graphic extensions instead of removing or splitting public APIs during the Unity 6.3 migration. Declare Mathematics 1.3.3 and uGUI 2.0.0 directly; remove unused Cinemachine and TMP declarations/references. Consumers must declare dependencies they actually use. Existing caller-controlled Mathematics symbols remain unchanged.

When serialized dictionary key/value lengths differ, log the existing error and leave the runtime dictionary empty. Partial restoration was considered and rejected by the user because malformed data should not silently become a partial mapping. Continuing after the diagnostic caused an index exception; early termination preserves an explicit diagnostic without an additional accidental exception. Matching data and serialized field names remain unchanged.
