# LumenCat
<div align="center">

![LumenCat92.jpg](https://github.com/lumenCat92/GizmosDrawer/blob/main/Image/LumenCat92.jpg)
</div>

# GizmosDrawer

# Language
<details>
<summary>English</summary>

# How Can Install This?

Before u install, this project depending other project. plz check each version of dependencies before download this.  
u can check each version of dependencies from package.json.  

Download this to Assets Folder in your unity project.

# What is This?

Drawing gizmos tool for debugging.

Most LumenCat projects use this for visualized debug purposes.

# Where Can Use This?

Generally its for personal thing but u can also using this.

for drawing line and sphere, u can use this easily. 

# How to Use This?

1. attached to gameObj as component in Scene.

2. if u dont wanna see the Gizmos, u can turn off "drawGizmos" option in inspector 

3. when u look at the code,
```csharp
public class GizmosDrawerManager : MonoBehaviour
{
    public static GizmosDrawerManager Instance { private set; get; }
    public bool drawGizmos = true;
    private List<GizmoInfo> gizmosToDraw = new List<GizmoInfo>();

    public void DrawLine(Vector3 startPosition, Vector3 endPosition, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = endPosition, Duration = duration, Color = color };
        AddGizmoInfo(gizmoInfo);
    }

    public void DrawLine(Vector3 startPosition, Vector3 dir, float dist, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = startPosition + dir * dist, Duration = duration, Color = color };
        AddGizmoInfo(gizmoInfo);
    }

    public void DrawSphere(Vector3 startPosition, float size, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new SphereGizmoInfo { StartPosition = startPosition, Radius = size, Duration = duration, Color = color, GizmoType = GizmoInfo.GizmosType.Sphere };
        AddGizmoInfo(gizmoInfo);
    }
}
```

for now only 2 drawing shape available.

(Honetly, it just for debugging. so for now i dont think i will need more than this.)


cause of last parametter, u can simply controling draw option in each script.
```csharp
class Holy
{
    bool isTrue = false;
    void Do()
    {
        // at least u dont have to do this.
        if(isTrue)
        {
            GizmosDrawerManager.Instance.DrawLine(Vector3.zero, Vector3.zero, 2f, Color.Magenta);
        }

        // do this!
        GizmosDrawerManager.Instance.DrawLine(Vector3.zero, Vector3.zero, 2f, Color.Magenta, isTrue);
    }
}
```

</details>

<details>
<summary>한국어</summary>

# 어떻게 설치하죠?

설치전, 해당 프로젝트는 다른 프로젝트에 디펜딩되어 있습니다. 각 버전마다 디펜딩된 프로젝트를 먼저 확인해주세요.  
각 버전 디펜던시는 package.json 파일을 통해 확인할 수 있습니다.  

이후 직접 다운로드해서 프로젝트의 Assets에 설치합니다.

# 이게 뭐죠?

디버깅용 드로잉 기즈모 툴입니다.

대부분의 LumenCat 프로젝트는 시각적 디버깅을 위해서 이를 사용합니다.

(일부 LumenCat 프로젝트에서는 해당 프로젝트에 디펜딩하고 있을 수 있습니다.)

# 어디에 쓰나요?

기본적으로는 개인적인 프로젝트 디버깅 용도로 사용하고 있지만 여러분도 사용하실 수는 있습니다.

간단한 선과 구 그리기를 지원합니다.

# 어떻게 사용하나요?

1. 싱글톤임으로 씬의 게임 오브젝트에 컴포넌트로 추가해주세요.

2. 기즈모를 보기 싫다면, 인스펙터에서 drawGizmos 옵션을 끌 수 있습니다.

3. 코드를 보면,
```csharp
public class GizmosDrawerManager : MonoBehaviour
{
    public static GizmosDrawerManager Instance { private set; get; }
    public bool drawGizmos = true;
    private List<GizmoInfo> gizmosToDraw = new List<GizmoInfo>();

    public void DrawLine(Vector3 startPosition, Vector3 endPosition, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = endPosition, Duration = duration, Color = color };
        AddGizmoInfo(gizmoInfo);
    }

    public void DrawLine(Vector3 startPosition, Vector3 dir, float dist, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = startPosition + dir * dist, Duration = duration, Color = color };
        AddGizmoInfo(gizmoInfo);
    }

    public void DrawSphere(Vector3 startPosition, float size, float duration, Color color, bool shouldDraw = true)
    {
        if (!shouldDraw) return;
        var gizmoInfo = new SphereGizmoInfo { StartPosition = startPosition, Radius = size, Duration = duration, Color = color, GizmoType = GizmoInfo.GizmosType.Sphere };
        AddGizmoInfo(gizmoInfo);
    }
}
```

현재는 두가지의 모형의 그리기만 지원합니다.
(사실 어차피 디버깅 용도라 현재로써는 이 이상의 기능이 필요할지는 모르겠습니다만, 필요에 따라서 추후 추가될 가능성은 있습니다.)

각 함수들의 마지막 파라메터 부분으로 인해, 각 스크립트에서 드로잉 여부를 쉽게 조절 할 수 있습니다.
```csharp
bool isTrue = false;
void Do()
{
    // 최소한 이건 할 필요 없다는 이야기.
    if(isTrue)
    {
        GizmosDrawerManager.Instance.DrawLine(Vector3.zero, Vector3.zero, 2f, Color.Magenta);
    }

    // 이렇게 하세요!
    GizmosDrawerManager.Instance.DrawLine(Vector3.zero, Vector3.zero, 2f, Color.Magenta, isTrue);
}
```