using System.Collections.Generic;

public class ModifierManager<T>
{
    LinkedList<ModifierBase<T>> modifierBases = new LinkedList<ModifierBase<T>>();

    public void Reset()
    {
        modifierBases.Clear();
    }
    public T GetValue(T _Value)
    {
        LinkedListNode<ModifierBase<T>> modifierNode = modifierBases.First;

        LinkedListNode<ModifierBase<T>> tempNode = null;

        T Value = _Value;


        while (null != modifierNode)
        {
            tempNode = modifierNode.Next;
            Value = modifierNode.Value.GetValue(_Value);
            if (null != tempNode)
            {
                modifierNode = tempNode;
            }
            else
            {
                return Value;
            }
        }
        return Value;
    }

    public void Update(float _DeltaTime)
    {
        LinkedListNode<ModifierBase<T>> modifierNode = modifierBases.First;

        LinkedListNode<ModifierBase<T>> tempNode = null;


        while (null != modifierNode)
        {
            tempNode = modifierNode.Next;
            if (true == modifierNode.Value.Update(_DeltaTime))
            {
                modifierBases.Remove(modifierNode.Value);
            }

            if (null != tempNode)
            {
                modifierNode = tempNode;
            }
            else
            {
                modifierNode = null;
            }
        }
    }

    public void AddModifier(ModifierBase<T> _modifierBase)
    {
        modifierBases.AddLast(_modifierBase);
    }

    public void RemoveModifier(ModifierBase<T> _modifierbase)
    {
        modifierBases.Remove(_modifierbase);
    }
}
