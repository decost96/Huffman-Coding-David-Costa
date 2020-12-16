using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCodeWithCSharp
{
    class HuffmanNode : IComparable<HuffmanNode>
    {
        public string symbol;   // Por el carácter de valor char. Público porque la clase Process lo usa.
        public int frequency;          // Número del recuento en archivo, cadena, texto.
        public string code;            // Obtener de un árbol para hacer un árbol huffman.
        public HuffmanNode parentNode; // Nodo padre del nodo actual.
        public HuffmanNode leftTree;   // Nodo izquierdo del nodo actual.
        public HuffmanNode rightTree;  // Nodo derecho del nodo actual.
        public bool isLeaf;            // Demuestra que es una hoja.


        public HuffmanNode(string value)    // Creando un Nodo con valor dado (carácter).
        {
            symbol = value;     // Configuración del símbolo.
            frequency = 1;      // Esta es la creación de Node, por lo que ahora su recuento es 1.

            rightTree = leftTree = parentNode = null;       // No tiene un árbol izquierdo o derecho y un padre.

            code = "";          // Se asignará en el árbol de creación. Ahora está vacío.
            isLeaf = true;      // Debido a que todos los nodos que creamos primero no tienen un nodo principal.
        }


        public HuffmanNode(HuffmanNode node1, HuffmanNode node2) // Únase a 2 Node para hacer Node.
        {
            // En primer lugar, estamos agregando las variables de estos 2 nodos. Excepto el nuevo árbol de Nodos izquierdo y derecho.
            code = "";
            isLeaf = false;
            parentNode = null;

            // Ahora el nuevo nodo necesita hoja. Son nodo1 y nodo2. si la frecuencia del nodo1 es mayor o igual que la frecuencia del nodo2. Es el árbol correcto. 
            // De lo contrario, árbol izquierdo. Los controladores están a continuación:
            if (node1.frequency >= node2.frequency)
            {
                rightTree = node1;
                leftTree = node2;
                rightTree.parentNode = leftTree.parentNode = this;     // "esto" significa el nuevo nodo!
                symbol = node1.symbol + node2.symbol;
                frequency = node1.frequency + node2.frequency;
            }
            else if (node1.frequency < node2.frequency)
            {
                rightTree = node2;
                leftTree = node1;
                leftTree.parentNode = rightTree.parentNode = this;     // "esto" significa el nuevo nodo!
                symbol = node2.symbol + node1.symbol;
                frequency = node2.frequency + node1.frequency;
            }
        }


        public int CompareTo(HuffmanNode otherNode) // Simplemente anulamos el método CompareTo. Porque cuando comparamos dos nodos, debe ser de acuerdo con las frecuencias de los nodos.
        {
            return this.frequency.CompareTo(otherNode.frequency);
        }


        public void frequencyIncrease()             // Cuando se enfrenta a un mismo valor en la lista de nodos, está aumentando la frecuencia de Node.
        {
            frequency++;
        }
    }
}
