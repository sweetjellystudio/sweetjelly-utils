#   Utils tests

Run SWeetJelly.Utils.Tests.EditMode and SWeetJelly.Utils.Tests.PlayMode separately on Unity 6.3 LTS. Preserve existing collection, string, vector and transform cases when changing utility behavior.

EditMode regression coverage includes dictionary round trips/mismatched lists, Mathematics conversions, Toggle state, task exception/cancellation propagation, inactive component injection, expanded drawer height and a real GUI event verifying indent preservation. The GUI-event test needs a graphics device: use a normal connected Editor or batch mode without -nographics. A missing graphics device is an environment failure, not a passing or skipped test.

PlayMode covers pending/already-completed ResourceRequest.AsTask, delayed disable/re-enable, Forget's exception handler and Graphic alpha. Expected malformed-data logs are asserted with LogAssert.Expect. Default no-handler async-void behavior is preserved and not advertised as swallowing exceptions.

Record actual Editor patch, target, executed/passed/failed/skipped counts and fresh reports. Development-host results, isolated declared-dependency results, real Inspector observation, Player compilation and post-publication Git-tag consumption are separate evidence. The development host owns temporary Inspector and minimal-consumer fixtures; this package does not ship a sample scene.