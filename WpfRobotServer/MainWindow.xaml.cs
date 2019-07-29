using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using RobotService;
using System.ServiceModel.Description;

namespace WpfRobotServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host = null;
        public MainWindow()
        {
            InitializeComponent();
            InitControls();
           // StartRobot();
        }

        private void InitControls()
        {
            KeysList.ItemsSource = new List<string>() { "A","B","Hello WOrld!!","{ENTER}" };
        }

        private void StartRobot()
        {
            try
            {
                //using (
                host = new ServiceHost(typeof(Robot));
                //{
                    //// Check to see if the service host already has a ServiceMetadataBehavior
                    //ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    //// If not, add one
                    //if (smb == null)
                    //    smb = new ServiceMetadataBehavior();
                    //smb.HttpGetEnabled = true;
                    //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    //host.Description.Behaviors.Add(smb);
                    //// Add MEX endpoint
                    //host.AddServiceEndpoint(
                    //  ServiceMetadataBehavior.MexContractName,
                    //  MetadataExchangeBindings.CreateMexHttpBinding(),
                    //  "mex"
                    //);
                    host.AddServiceEndpoint(typeof(IRobot),
                        new WSDualHttpBinding(), "http://localhost:8080/robotService/");

                   // host.AddServiceEndpoint(typeof(IRobot),
                    //    new WSHttpBinding(), "http://localhost:8080/robotService/wsAddress");

                    //host.AddServiceEndpoint(typeof(IRobot),

                    //    new NetTcpBinding(), "net.tcp://localhost:8081/RobotService");

                    host.Open();
                //}
            }
            catch (Exception ex)
            {
                host.Abort();
                MessageBox.Show("Error = " + ex.Message);
            }
        }
    }
}
