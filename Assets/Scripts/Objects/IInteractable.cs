public interface IInteractable
{
    void OnInteractEnter();

    void OnInteractPress(PlayerInventory playerInventory);
    
    void OnInteractExit();
}