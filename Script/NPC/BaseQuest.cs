using UnityEngine;

public abstract class BaseQuest : ScriptableObject
{
    public string questTitle;
    public string questDescription;
    public bool isStarted;
    public bool isCompleted;
    public string questStartDescription;
    public string questCompletionDescription;

    public abstract void StartQuest();
    public abstract void CompleteQuest();
}
