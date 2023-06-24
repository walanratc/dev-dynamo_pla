using DevDynamo.Models;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DevDynamo.Tests
{
  public class ProjectTest
  {
    public class General
    {
      [Fact]
      public void NewProject()
      {
        var project = new Project(name: "test");
        Assert.NotNull(project);
        Assert.Equal("test", project.Name);
        Assert.Empty(project.WorkflowSteps);
        Assert.Empty(project.Tickets);
      }
    }
    public class LoadWorkflowTemplate
    {
      [Fact]
      public void Test1()
      {
        var p = new Project("test");
        var template = @"stateDiagram
    [*]--> ToDo : Create Ticket
    ToDo--> Doing : Developer Starts
    Doing--> ReadyToTest : Developer Finishes
    Doing--> ToDo : Reset
    ReadyToTest --> Done : Test Passed
    ReadyToTest--> Reopen : Test Failed
    Reopen--> Doing : Developer Reopens
    Done--> [*] : Close Ticket";

        p.LoadWorkflowTemplate(template);

        Assert.Equal(8, p.WorkflowSteps.Count);
        var s1 = p.WorkflowSteps.First();
        Assert.Equal("[*]", s1.FromStatus);
        Assert.Equal("ToDo", s1.ToStatus);
        Assert.Equal("Create Ticket", s1.Action);
      }

    }

  }
}