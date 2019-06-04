using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRMDesktopUI.ViewModels;

// This Class is based on Caliburn Micro Documentation Bootstrap with Simple Container
// https://caliburnmicro.com/documentation/simple-container
namespace TRMDesktopUI
{
  public class Bootstrapper : BootstrapperBase
  {
    // Must Have for CaliburnMicro Container to work 
    private readonly SimpleContainer container = new SimpleContainer();

    public Bootstrapper() { Initialize(); }

    protected override void Configure()
    {
      this.container
        // Sets what is the instance of container to be used for the App
        .Instance(this.container);

      this.container
        // Manage Windows in the App, bringing windows in and out
        .Singleton<IWindowManager, WindowManager>()
        // Event container to pass event between different components
        .Singleton<IEventAggregator, EventAggregator>();

      GetType().Assembly.GetTypes()
        .Where(type => type.IsClass)
        .Where(type => type.Name.EndsWith("ViewModel")) // return IEnumerable
        .ToList()
        .ForEach(viewModelType => 
          // interface / key / implementation
          this.container.RegisterPerRequest(
            viewModelType, 
            viewModelType.ToString(),
            viewModelType
          )
        );
    }

    protected override void OnStartup(object sender, StartupEventArgs e) =>
      DisplayRootViewFor<ShellViewModel>();

    // Must Have for CaliburnMicro Container to work 
    protected override object GetInstance(Type service, string key) => 
      this.container.GetInstance(service, key);

    // Must Have for CaliburnMicro Container to work 
    protected override IEnumerable<object> GetAllInstances(Type service) => 
      this.container.GetAllInstances(service);

    // Must Have for CaliburnMicro Container to work 
    protected override void BuildUp(object instance) => 
      this.container.BuildUp(instance);
  }
}
