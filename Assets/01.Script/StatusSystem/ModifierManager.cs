using System.Collections.Generic;
using System.Collections;

public class ModifierManager<T>
{
    LinkedList<ModifierBase<T>> modifierBases = new LinkedList<ModifierBase<T>>();


    public T GetValue(T _Value)
    {
        LinkedListNode<ModifierBase<T>> modifierNode = modifierBases.First;

        LinkedListNode<ModifierBase<T>> tempNode = null;

        T Value = _Value;


        while (null != modifierNode)
        {
            tempNode = modifierNode.Next;
            Value = modifierNode.Value.GetValue(_Value);
            if(null != tempNode)
            {
                modifierNode = tempNode;
            }
        }

        return Value;
    }
}
