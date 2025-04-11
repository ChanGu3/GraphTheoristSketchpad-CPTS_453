# GraphTheoristSketchpad-CPTS_453

## What I learned
When first beginning this project I was not sure what to use to build the graph theorist sketchpad so i used winforms as I learned about this GUI in my CPTS_321 course and did not havent prior exprience with any other graphical user interface. During the creation process I realized that winforms isn't the best at processing tons of real time actions and I should have used a different framework non the less this turned out pretty well. 
My design and architecture definitely could use tons of work however I was pleased with this project!

## How To Use 
Introduction:
  The way the UI is handled is here is if a user wants to interact with the graphical interface to 
vertices and edges it’s in the left middle zone. However, most interactions will be done on 
the right side of the graphical interface called the main controls. The following are 
instructions to do each possible action in the application from start to end. 
There are 5 main controls in total that are going to be navigated by the user, First the Create 
a Graph Menu shows up when first opening application or resetting the graph to choose a 
graph to play with, Second the No Select Menu this menu shows up when you have no 
objects selected in the graph zone, Third the Vertex Select Menu which shows up when 
selecting one vertex, Fourth the Two Vertex Select Menu which show up when selecting 
two vertexes, and finally the fifth Edge Select Menu for when selecting An edge. All 
selections are done in the graph zone and clicking the objects clicking outside of the object 
in the graph zone will bring back the no-select menu  
The following are Guides to use the application appropriately, 

- Create Graph or Reset Graph: 
  In the Create a Graph Menu you will have a choice of a weighted or a non
weight graph and a choice of a directed and non-directed graph. This will determine how 
the graph can be manipulated after this choice. When working on a graph if you decide you 
want to choose another type of graph you can press the reset graph button to go back to 
Create a Graph Menu. 

- Create Vertex: 
A vertex can be created by clicking on the graph zone of the application where 
a context menu will pop up where an option to create a vertex can be selected. This will 
create the vertex where your cursor is. 

- Create Edge: 
Depending on the type of graph some of these options may not show up due to 
keeping the graph sound. In one of the Main controls on the right side there are options of a 
directed or non-directed edge causing an edge with an arrow or an edge with no arrow to 
represent a loop using both vertices. Another possible option may be to choose the weight 
of an edge before creation. These can be created by buttons after filling in optional values 
in the Vertex Select Menu for loops onto the same vertex or the Two Vertex Select for an 
edge from one vertex to another where the first vertex selected is the “From” and the 
second vertex selected is the “To” in order of selection. 

- Change Color of Vertex or Edge: 
In both the Vertex Select Menu and the Edge Select Menu a choice of 
coloring these object is used by pressing its choose color option next to its current color in 
those menus. To Reset the color palette of all objects in the No Select Menu a reset object 
colors button will do exactly that. 
Changing vertex name Label or Showing edge weight and vertex name labels: 
In the Vertex Select Menu there is a section where you can see the name of 
the vertex replacing that text with the name of the vertex. If you want to see the labels of 
edges or vertices you must go to the No Select Menu and check mark for each vertex 
names and edge weights show for visibility or hide for invisibility.  

- Remove Edge or Vertex: 

Removing objects is Straight forward in the Vertex Select Menu and the Edge 
Select Menu a button exists called remove “object name”. this will remove that object and 
if it is connected to other objects, it will destroy those namely a vertex connected to edges 
destroyed will destroy all edges it’s a part of. 

- Shortest Path Pop-Up: 
To use this, go to the Vertex Select Menu by choosing a vertex and then press 
the shortest path this will pop up a shortest path data form with labeled vertices along with 
labeling them in the graph zone. 

- Open Adjacency Matrix: 
Similar to shortest path Pop-Up instead use the No Select Menu by having no 
object selected and then press the “open adjacency matrix” this will pop up an adjacency 
matrix data form with labeled vertices along with labeling them in the graph zone. 

- Check Bi-Partite-ness: 
In the No Select Menu a press the “check Bi_Partiteness” button once clicked 
the value below the button will give you a true or false whether the current graph is in fact 
bi-partite. Two of the following can occur when false it may be that every vertex will be 
colored however it will color all the vertexes checked up to the point where a vertex cannot 
be two colors and give a random color to show the 2-color bi-partite-ness check. 
Otherwise, true then all vertexes will be colored showing two partite sets.


## What Next For This Project
If I were to continue this project the following would be things I would like to introduce.
- First design a architecuture and use good practices and patterns and trying my best to rid of any anti-patterns
- Add new features such chromatic coloring, re-sizing the graphical view of the graph as well as dragging the view to create more space.
- Design the UI to be scalable so that resizing the window doesnt break the format of the UI
- Use a different framework to display the graphs but still use winforms UI
- Allow portablilty by moving the subsystem for the graphical framework and the model of the graph using Avalonia instead of winforms
