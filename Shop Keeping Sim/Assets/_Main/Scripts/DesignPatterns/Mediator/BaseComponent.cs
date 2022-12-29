using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    protected IMediator Mediator;

    public void SetMediator(IMediator mediator) => Mediator = mediator;
}
