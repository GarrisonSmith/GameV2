using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using System.Collections.Generic;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A stack containing <cref>ICameraTask</cref> in the order they will be executed. 
	/// </summary>
	public class TaskStack
	{
		private ICameraTask bottomItem;
		private Stack<ICameraTask> tasks;

		/// <summary>
		/// The bottom task in the stack. Can only be a <cref>FollowILocationTask</cref> or a <cref>FreeMovementTask</cref>.
		/// </summary>
		public ICameraTask BottomItem
		{
			get => bottomItem;
			set
			{
				if (value is FollowILocationTask || value is FreeMovementTask)
				{ 
					bottomItem = value;
				}
			}
		}
		/// <summary>
		/// The task stack. 
		/// </summary>
		private Stack<ICameraTask> Tasks { get => tasks; }

		/// <summary>
		/// Creates a new TaskStack.
		/// </summary>
		/// <param name="bottomItem">The bottom task in the stack.</param>
		public TaskStack(FollowILocationTask bottomItem)
		{
			this.bottomItem = bottomItem;
			tasks = new Stack<ICameraTask>();
			tasks.Push(bottomItem);
		}
		/// <summary>
		/// Creates a new TaskStack.
		/// </summary>
		/// <param name="bottomItem">The bottom task in the stack.</param>
		public TaskStack(FreeMovementTask bottomItem)
		{
			this.bottomItem = bottomItem;
			tasks = new Stack<ICameraTask>();
			tasks.Push(bottomItem);
		}

		/// <summary>
		/// Pushes a task to the TaskStack.
		/// </summary>
		/// <param name="task">The task to be added.</param>
		public void Push(ICameraTask task)
		{
			task.StartTask();
			Tasks.Push(task);
		}
		/// <summary>
		/// Pops the top task in the stack.
		/// </summary>
		/// <returns>The top task in the stack.</returns>
		public ICameraTask Pop() 
		{
			return Tasks.Pop();
		}
		/// <summary>
		/// Peeks the top task in the stack.
		/// </summary>
		/// <returns>The top task in the stack.</returns>
		public ICameraTask Peek() {
			return Tasks.Peek();
		}
		/// <summary>
		/// Updates the task stack by progressing the top task and popping it from <cref>Tasks</cref> if the task is complete. 
		/// </summary>
		public void Update() 
		{
			if (Tasks.Peek().ProgressTask())
			{
				Tasks.Pop();
				Tasks.Peek().StartTask();
			}
		}

	}
}
