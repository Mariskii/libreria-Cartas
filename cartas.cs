using System;

namespace cartas
{
    public class libreria
    {
        public enum Epalo
        {
            Treboles,
            Corazones,
            Picas,
            Diamantes
        }
       public enum Evalores
        {
            As = 1,
            Dos = 2,
            Tres = 3,
            Cuatro = 4,
            Cinco = 5,
            Seis = 6,
            Siete = 7,
            Ocho = 8,
            Nueve = 9,
            Diez = 10,
            Jota = 11,
            Reina = 12,
            Rey = 13

        }

        public class Card
        {
            public Epalo palo{get;set;}
            public Evalores valor{get;set;}

            public Card(Epalo palo,Evalores valor){
                this.palo=palo;
                this.valor=valor;
            }
            
            //muestra las cartas en formato texto
            public override string ToString(){
                return "Carta: "+valor+" de "+palo; 
            }

            /*El metodo muestra la carta por pantalla en un formato que imita el de una carta física
            */
            public void muestraCarta()
            {
                Console.WriteLine("┌─────────────┐");
                if((int)valor == 10)
                    Console.WriteLine("│ "+muestraValor((int)valor)+"          │");
                else
                    Console.WriteLine("│ "+muestraValor((int)valor)+"           │");
                Console.WriteLine("│             │");
                Console.WriteLine("│             │");
                Console.WriteLine("│      "+muestraPalo((int)palo)+"      │");
                Console.WriteLine("│             │");
                Console.WriteLine("│             │");
                if((int)valor == 10)
                    Console.WriteLine("│          "+muestraValor((int)valor)+" │");
                else
                    Console.WriteLine("│           "+muestraValor((int)valor)+" │");
                Console.WriteLine("└─────────────┘");
            }

            /**Este metodo sirve para devolver la letra asociada a cada valor especial, como el as o la rey, cuyo valor es K.
            *En caso de que el valor no tenga ningun valor asociado, como el 2 o el 5 devolvera el numero, no hay conversión
            */
            public string muestraValor(int val)
            {
                switch (val)
                {
                    case 1:
                        return "A";
                    break;

                    case 11:
                        return "J";
                    break;

                    case 12:
                        return "Q";
                    break;

                    case 13:
                        return "K";
                    break;

                    default:
                        return ""+val;
                }
            }

            /**Metodo que devuelve el caracter asociado a cada valor de la Enum de Epalo, por ejemplo, si el palo es un
            *trebol el metodo devolverá el carácter del trebol
            */
            public string muestraPalo(int palo)
            {
                switch (palo)
                {
                    // '♠', '♦', '♥', '♣'
                    case 0:
                        return "♣";
                    break;

                    case 1:
                        return "♥";
                    break;

                    case 2:
                        return "♠";
                    break;

                    case 3:
                        return "♦";
                    break;

                    default:
                        return "";
                }
            }
        }

        public class Deck
        {
            private Card[] baraja; //Array de cartas 1 DIMENSIÓN
            public static int MAX = 52;//Numero máximo de cartas que tiene la baraja

            public Deck()
            {
                int cont=0;

                baraja = new Card[MAX];

                for(int i=0; i<4; i++)
                {
                    for(int j=1; j<14;j++)
                    {
                        baraja[cont]=new Card((Epalo)(i),(Evalores)(j));
                        cont++;
                    }
                }
            }
            
            //Muestra todas las cartas de la baraja en formato Texto
            public void muestraBaraja()
            {
                foreach (Card carta in baraja)
                {
                    Console.WriteLine(carta.ToString());
                }
            }

            //Baraja las cartas intecambiando la posicion de una carta por otra aleatoria de la baraja
            public void barajar()
            {
                Card cartaAux = new Card(Epalo.Treboles,Evalores.As);
                Random rdm = new Random();
                int posicionRandom;

                for (int i = 0; i < getNumCartas(); i++)
                {
                    posicionRandom = rdm.Next(0, getNumCartas());
                    
                    //Cambiar los valores de las cartas con la ayuda de una carta auxiliar
                    cartaAux = baraja[i];
                    baraja[i] = baraja[posicionRandom];
                    baraja[posicionRandom] = cartaAux;
                }
            }

            
            /*El metodo devuelve una carta y la eliminará de la baraja, pero si se intentan sacar una carta
            *cuando no queda ninguna, el método devolverá null
            */
            public Card sacarCarta()
            {
                Card carta = null;

                if(getNumCartas() >= 1)
                {
                    carta = baraja[baraja.Length-1];

                    Array.Resize(ref baraja, baraja.Length - 1);
                }
                    
                return carta;
            }

            //devuelve el numero de cartas que hay en la baraja
            public int getNumCartas()
            {
                return baraja.Length;
            }
        }
    }
}