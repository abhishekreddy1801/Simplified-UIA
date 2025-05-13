public class UiaSearchEngine
{
    private AutomationElement _rootElement;
    private Condition _condition = Condition.TrueCondition;
    private TreeScope _treeScope = TreeScope.Descendants;
 
    private UiaSearchEngine(AutomationElement rootElement, TreeScope treeScope)
    {
        _rootElement = rootElement;
        _treeScope = treeScope;
    }
 
    public static UiaSearchEngine Descendants(AutomationElement rootElement)
    {
        return new UiaSearchEngine(rootElement, TreeScope.Descendants);
    }
 
    public static UiaSearchEngine Children(AutomationElement rootElement)
    {
        return new UiaSearchEngine(rootElement, TreeScope.Children);
    }
 
    public UiaSearchEngine WithName(string name)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.NameProperty, name));
        return this;
    }
 
    public UiaSearchEngine WithAutomationId(string automationId)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
        return this;
    }
 
    public UiaSearchEngine WithClassName(string className)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.ClassNameProperty, className));
        return this;
    }
 
    public UiaSearchEngine IsEnabled(bool isEnabled)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.IsEnabledProperty, isEnabled));
        return this;
    }
 
    public UiaSearchEngine IsVisible(bool isVisible)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.IsOffscreenProperty, !isVisible));
        return this;
    }
 
    public UiaSearchEngine WithControlType(ControlType controlType)
    {
        _condition = new AndCondition(_condition, new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
        return this;
    }
 
    public AutomationElement FindFirst()
    {
        var element = _rootElement.FindFirst(_treeScope, _condition);
        if(element == null)
        {
            throw new Exception("Element not found");
        }
        return element;
    }
 
    public IEnumerable<AutomationElement> FindAll()
    {
        return _rootElement.FindAll(_treeScope, _condition).Cast<AutomationElement>();
    }
}