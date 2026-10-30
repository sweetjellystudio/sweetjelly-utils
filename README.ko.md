# SWeetJelly Utilities

Unity 프로젝트를 위한 작은 runtime/editor utility 패키지입니다.

이 패키지는 extension method, 작은 utility class, serializable helper type, editor drawer 같은 기술적 편의 기능만 담도록 의도되어 있습니다. application contract, domain decision, shared architectural language를 소유하지 않아야 합니다.

## 책임

application이 success, failure, policy, ownership, lifecycle을 어떻게 의미화하는지 정의하지 않는 helper에 사용합니다.

잘 맞는 항목:

- collection, string, number, vector, transform, Unity object extension
- camera, renderer, texture, layer mask, resources, time 같은 작은 Unity helper
- enum, random, reflection, IO, vector utility 같은 generic utility helper
- `SerializableDictionary`, `DuoTypes`, `ToggleTypes` 같은 가벼운 serializable helper type
- 위 helper type을 위한 editor-only drawer

맞지 않는 항목:

- `Result`, `Error`, `Verdict` 같은 shared contract model
- package-specific error code 또는 block reason
- domain policy, application service contract, save/load/loading outcome, business rule
- 다른 패키지가 architectural language 때문에 Utils에 의존하게 만드는 타입

이런 타입은 shared/foundation package 또는 구체적 의미를 소유하는 패키지에 둡니다.

## 어셈블리

- `SWeetJelly.Utils`
- `SWeetJelly.Utils.Editor`

runtime assembly는 auto-reference되며 root namespace는 `SWeetJelly`입니다.

## Runtime 내용

### Extensions

일반적인 .NET 타입과 Unity 타입을 위한 extension method를 포함합니다.

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

예시:

```csharp
using SWeetJelly;

if (items.IsNullOrEmpty())
{
    return;
}

playerTransform.ResetLocal();
```

### Utilities

작은 static helper를 포함합니다.

- `EnumUtils`
- `IOUtils`
- `RandomUtils`
- `ReflectionUtils`
- `ResourcesUtils`
- `RuntimeEditorUtils`
- `TimeUtils`
- `VectorUtils`

예시:

```csharp
using SWeetJelly;

bool selected = RandomUtils.TrueFalse();
```

### Extras

가벼운 helper type과 component를 포함합니다.

- `SerializableDictionary`
- `Bezier`
- `DelayedObjectDisabler`
- `DuoTypes`
- `FPSCounter`
- `PhysicsHelper`
- `ToggleTypes`

## Editor 내용

editor assembly는 utility helper type을 위한 drawer를 제공합니다.

- `SerializableDictionaryDrawer`
- `DuoTypesPropertyDrawer`
- `ToggleTypesPropertyDrawer`

## 패키지 경계

`Utils`는 shared policy나 result semantics를 소유하지 않기 때문에 feature package가 부담 없이 참조할 수 있어야 합니다.

예시:

```text
Loading -> Utils
Save -> Utils
Serialization -> Utils
```

반면 shared outcome model은 foundation/shared package에서 흘러와야 합니다.

```text
Save -> Shared.Result
Loading -> Shared.Result
Serialization -> Shared.Result
```

요약:

```text
Utils = technical convenience helper
Shared/Foundation = 의미 있는 공통 contract
Feature package = 구체적인 error, reason, policy
```

## 2.0.0 이전과 설치

Unity 6.3 LTS, com.unity.mathematics 1.3.3, com.unity.ugui 2.0.0이 필요합니다. 게시 후 Unity Package Manager에서 https://github.com/sweetjellystudio/sweetjelly-utils.git#v2.0.0 을 설치합니다. 사용하지 않는 Cinemachine·독립 TMP 패키지 의존성은 제거했습니다. 소비 프로젝트에서 사용하는 패키지는 그 프로젝트가 직접 선언하세요. Duo 변환 때문에 Mathematics는 필요하며 기존 ENABLED_UNITY_MATHEMATICS 조건부 API는 자동 활성화하지 않습니다.

공개 helper 시그니처와 직렬화 필드명은 유지합니다. 직렬화 dictionary의 key/value 길이가 다르면 기존 오류 로그 후 빈 상태로 종료하며, 부분 복원 뒤 인덱스 예외가 발생하던 동작은 수정했습니다. 정상 데이터는 기존과 동일합니다. Drawer는 펼친 행 높이와 들여쓰기를 올바르게 유지하고 잘못된 목록에는 오류를 표시합니다.

[아키텍처][architecture]와 [이전 결정][decision]을 참고하세요. 실제 검증 Editor 패치·플랫폼은 결과에서 별도로 확인하며 모든 환경 검증을 의미하지 않습니다.

[architecture]: ARCHITECTURE.md
[decision]: docs/adr/0001-dependencies-and-malformed-serialization.md