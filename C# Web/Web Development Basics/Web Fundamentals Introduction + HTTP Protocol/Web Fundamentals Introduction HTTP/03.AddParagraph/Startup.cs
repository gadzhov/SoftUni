using System;

namespace _03.AddParagraph
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");

            Console.WriteLine("<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF - 8\">    <meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\">    <meta http-equiv=\"X - UA - Compatible\" content=\"ie = edge\">    <title>Document</title></head><body>    <h1>By the Cake</h1>    <h2>Enjoy our awesome cakes</h2>    <hr>    <ul>        <li>Home</li>        <ol>            <li>Our Cakes</li>            <li>Our Stores</li>        </ol>        <li>Add Cake</li>        <li>Browse Cake</li>        <li>About Us</li>    </ul>    <h2>Home</h2>    <section>        <h3>Our Cakes</h3>        <p>Cake is a form of sweet dessert that is typically baked. In its oldest forms, cakes were modifications of breads, but cakes now cover a wide range of preparations that can be simple or elaborate, and that share features with other desserts such as pastries, meringues, custards, and pies.</p>        <img src=\"https://www.bbcgoodfood.com/sites/default/files/recipe-collections/collection-image/2013/05/matcha-mousse-cake.jpg\" alt=\"cake\">    </section>    <section>        <h3>Our Stores</h3>        <p>Our stores are located in 21 cities all over the world. Come and see what we have for you.</p>        <img src=\"https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2016/07/pimms-cake.jpg?itok=Jfan_PED\" alt=\"cake\">    </section></body></html>");        
                }
    }
}
