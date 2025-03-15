using GTS_GraphEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_Controls
{
    public class SelectedItems
    {
        Queue<VertexUserControl> vertexUserControls = new();
        EdgeUserControl? edgeUserControl = null;

        public SelectedItems() { }

        public EdgeUserControl? EdgeUserControl
        {
            get => edgeUserControl;
        }

        public Queue<VertexUserControl>? VertexUserControls
        {
            get
            {
                if( vertexUserControls.Count == 0 )
                { 
                    return null;
                }

                return vertexUserControls;
            }
        }

        public void AddSelectedItem(object? item)
        {
            if (item is VertexUserControl itemVertex) 
            {
                if (vertexUserControls.Contains(itemVertex))
                {
                    return;
                }
                else if (edgeUserControl != null)
                {
                    edgeUserControl.IsHighlighted = false;
                    edgeUserControl = null;
                }
                else if (vertexUserControls.Count == 2)
                {
                    vertexUserControls.Dequeue().IsHighlighted = false;

                    itemVertex.IsHighlighted = true;
                    vertexUserControls.Enqueue(itemVertex);
                }
                else
                {
                    itemVertex.IsHighlighted = true;
                    vertexUserControls.Enqueue(itemVertex);
                }

               // itemVertex.Invalidate();
            }
            else if (item is EdgeUserControl itemEdge)
            {
                if (edgeUserControl == itemEdge)
                {
                    return;
                }

                if (vertexUserControls.Count > 0)
                {
                    while (vertexUserControls.Count != 0)
                    {
                        vertexUserControls.Dequeue().IsHighlighted = false;
                    }
                }

                if (edgeUserControl != null)
                {
                    edgeUserControl.IsHighlighted = false;
                }

                itemEdge.IsHighlighted = true;
                edgeUserControl = itemEdge;
            }
        }

        public void Clear()
        {
            if (vertexUserControls.Count > 0)
            {
                while (vertexUserControls.Count != 0)
                {
                    vertexUserControls.Dequeue().IsHighlighted = false;;
                }
            }

            if (edgeUserControl != null)
            {
                edgeUserControl.IsHighlighted= false;
            }
        }
    }
}
