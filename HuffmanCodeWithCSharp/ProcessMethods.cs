using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HuffmanCodeWithCSharp
{
    class ProcessMethods
    {
        //  Crea una lista de nodos que lee los caracteres del archivo.
        public List<HuffmanNode> getListFromFile()
        {
            List<HuffmanNode> nodeList = new List<HuffmanNode>();  // Lista de nodos.

            Test.setColor();
            Console.WriteLine("Example file: \"a.txt\"\n");
            Test.setColorDefault();           
            Console.Write("Enter the path of the file: ");
            String filename = Console.ReadLine();
            try
            {
                // Creando un nuevo nodo único que lee del archivo.
                // Si es del mismo carácter, aumente la frecuencia del valor. Es posible con el método de "aumento de frecuencia ()".
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < stream.Length; i++)
                {
                    string read = Convert.ToChar(stream.ReadByte()).ToString();
                    if (nodeList.Exists(x => x.symbol == read)) // ¿Comprobando el valor que ha creado antes?
                        nodeList[nodeList.FindIndex(y => y.symbol == read)].frequencyIncrease(); // Si es así, busque el índice del nodo y aumente la frecuencia del nodo.
                    else
                        nodeList.Add(new HuffmanNode(read));   // Si es no, cree un nuevo nodo y agréguelo a la Lista de nodos
                }
                nodeList.Sort();   // Ordene los nodos de la lista según su valor de frecuencia.
                return nodeList;
            }
            catch (Exception)
            {
                return null;
            }

        }


        //  Crea un árbol según los nodos (frecuencia, símbolo)
        public void getTreeFromList(List<HuffmanNode> nodeList)
        {
            while (nodeList.Count > 1)  // 1 porque un árbol necesita 2 hojas para formar un nuevo padre.
            {
                HuffmanNode node1 = nodeList[0];    // Obtenga el nodo del primer índice de List,
                nodeList.RemoveAt(0);               // y eliminarlo.
                HuffmanNode node2 = nodeList[0];    // Obtenga el nodo del primer índice de List,
                nodeList.RemoveAt(0);               // y eliminarlo.
                nodeList.Add(new HuffmanNode(node1, node2));    // Envío del constructor para crear un nuevo nodo a partir de estos nodos.
                nodeList.Sort();        // y ordenarlo de nuevo según la frecuencia.
            }
        }


        // Configuración de los códigos de los nodos del árbol. Método recursivo.
        public void setCodeToTheTree(string code, HuffmanNode Nodes)
        {
            if (Nodes == null)
                return;
            if (Nodes.leftTree == null && Nodes.rightTree == null)
            {
                Nodes.code = code;
                return;
            }
            setCodeToTheTree(code + "0", Nodes.leftTree);
            setCodeToTheTree(code + "1", Nodes.rightTree);
        }


        // ¡Imprimiendo todo el árbol! Método recursivo.
        public void PrintTree(int level, HuffmanNode node)
        {
            if (node == null)
                return;
            for (int i = 0; i < level; i++)
            {
                Console.Write("\t");
            }
            Console.Write("[" + node.symbol + "]");
            Test.setColor();
            Console.WriteLine("(" + node.code + ")");
            Test.setColorDefault();
            PrintTree(level + 1, node.rightTree);
            PrintTree(level + 1, node.leftTree);
        }


        //  Imprimir la información del nodo en la lista de nodos
        public void PrintInformation(List<HuffmanNode> nodeList)
        {
            foreach (var item in nodeList)
                Console.WriteLine("Symbol : {0} - Frequency : {1}", item.symbol, item.frequency);
        }


        // Imprimir los símbolos y códigos de los Nodos en el árbol.
        public void PrintfLeafAndCodes(HuffmanNode nodeList) 
        {
            if (nodeList == null)
                return;
            if (nodeList.leftTree == null && nodeList.rightTree == null)
            {
                Console.WriteLine("Symbol : {0} -  Code : {1}", nodeList.symbol, nodeList.code);
                return;
            }
            PrintfLeafAndCodes(nodeList.leftTree);
            PrintfLeafAndCodes(nodeList.rightTree);
        }

    }
}
