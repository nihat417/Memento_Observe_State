using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_Observe_State.State;

interface MobileAlertState
{
    void Alert(AlertStateContext ctx);
}

class AlertStateContext
{
    private MobileAlertState currentState;

    public AlertStateContext()
    {
        currentState = new Vibration();
    }

    public void SetState(MobileAlertState state) => currentState = state;
    public void Alert() => currentState.Alert(this);
}

class Vibration : MobileAlertState
{
    public void Alert(AlertStateContext ctx) => Console.WriteLine("Vibration...");
}

class Silent : MobileAlertState
{
    public void Alert(AlertStateContext ctx) => Console.WriteLine("Silent...");
}

class Program
{
    static void Main()
    {
        AlertStateContext alertStateContext = new AlertStateContext();
        alertStateContext.Alert();
        alertStateContext.Alert();
        alertStateContext.Alert();
        alertStateContext.SetState(new Silent());
        alertStateContext.Alert();
    }
}