using System;
using System.IO;



/* для подключения System.Drawing в своем проекте правой в проекте нажать правой кнопкой по Ссылкам -> Добавить ссылку
    отметить галочкой сборку System.Drawing    */
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Linq;
using ImgApp;

namespace IMGapp
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Попиксельная сумма");
            Console.WriteLine("2. Попиксельное среднее арифметическое");
            Console.WriteLine("3. Попиксельный максимум");
            Console.WriteLine("4. Нарисовать гистограмму x^2");
            Console.WriteLine("5. Нарисовать гистограмму sqrt(x)");
            Console.WriteLine("6. Бинаризация методом Гарвилова");
            Console.WriteLine("7. Линейный матричный фильтр");
            Console.WriteLine("8. Медианный матричный фильтр");
            Console.WriteLine("9. Фурье преобразование (WIP)");
            Console.WriteLine("10. Выход");

            var caseSwitch = Console.ReadLine();

            do
            {
                switch (caseSwitch)
                {
                    //1. Попиксельная сумма
                    #region Попиксельная сумма
                    case "1":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {     
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");


                            var w1 = img1.Width;
                            var h1 = img1.Height;

                            using (var img2 = new Bitmap("..\\..\\in2.jpg"))
                            {
                                Console.WriteLine("Открываю второе изображение " + Directory.GetParent("..\\..\\") + "\\in2.jpg");


                                var w2 = img2.Width;
                                var h2 = img2.Height;

                                if (w1 != w2 && h1 != h2)
                                {
                                    Console.WriteLine("Размер картинок не совпадает");
                                    return;
                                }

                                using (var img_out1 = new Bitmap(w1, h1))   //создаем пустое изображение размером с исходное для сохранения результата
                                {
                                    var time1 = DateTime.Now;



                                    for (int i = 0; i < h1; ++i)
                                    {
                                        for (int j = 0; j < w1; ++j)
                                        {
                                            var pix1 = img1.GetPixel(j, i);

                                            int r1 = pix1.R;
                                            int g1 = pix1.G;
                                            int b1 = pix1.B;

                                            var pix2 = img2.GetPixel(j, i);

                                            int r2 = pix2.R;
                                            int g2 = pix2.G;
                                            int b2 = pix2.B;

                                            r1 = (int)Clamp(r1 + r2, 0, 255);
                                            g1 = (int)Clamp(g1 + g2, 0, 255);
                                            b1 = (int)Clamp(b1 + b2, 0, 255);

                                            pix1 = Color.FromArgb(r1, g1, b1);
                                            img_out1.SetPixel(j, i, pix1);
                                        }
                                    }

                                    var time2 = DateTime.Now;
                                    Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                    img_out1.Save("..\\..\\out1.jpg");

                                    Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out1.jpg");
                                    //Console.ReadKey();
                                }
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //2.Попиксельное среднее арифметическое
                    #region Попиксельное среднее арифметическое
                    case "2":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {    
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");


                            var w1 = img1.Width;
                            var h1 = img1.Height;

                            using (var img2 = new Bitmap("..\\..\\in2.jpg"))
                            {
                                Console.WriteLine("Открываю второе изображение " + Directory.GetParent("..\\..\\") + "\\in2.jpg");


                                var w2 = img2.Width;
                                var h2 = img2.Height;

                                if (w1 != w2 && h1 != h2)
                                {
                                    Console.WriteLine("Размер картинок не совпадает");
                                    return;
                                }

                                using (var img_out2 = new Bitmap(w1, h1))   //создаем пустое изображение размером с исходное для сохранения результата
                                {
                                    var time1 = DateTime.Now;



                                    for (int i = 0; i < h1; ++i)
                                    {
                                        for (int j = 0; j < w1; ++j)
                                        {
                                            var pix1 = img1.GetPixel(j, i);

                                            int r1 = pix1.R;
                                            int g1 = pix1.G;
                                            int b1 = pix1.B;

                                            var pix2 = img2.GetPixel(j, i);

                                            int r2 = pix2.R;
                                            int g2 = pix2.G;
                                            int b2 = pix2.B;

                                            r1 = (int)Clamp((r1 + r2) / 2, 0, 255);
                                            g1 = (int)Clamp((g1 + g2) / 2, 0, 255);
                                            b1 = (int)Clamp((b1 + b2) / 2, 0, 255);

                                            pix1 = Color.FromArgb(r1, g1, b1);
                                            img_out2.SetPixel(j, i, pix1);
                                        }
                                    }

                                    var time2 = DateTime.Now;
                                    Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                    img_out2.Save("..\\..\\out2.jpg");

                                    Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out2.jpg");
                                    //Console.ReadKey();
                                }
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //3. Попиксельный максимум
                    #region Попиксельный максимум
                    case "3":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {     
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");


                            var w1 = img1.Width;
                            var h1 = img1.Height;

                            using (var img2 = new Bitmap("..\\..\\in2.jpg"))
                            {
                                Console.WriteLine("Открываю второе изображение " + Directory.GetParent("..\\..\\") + "\\in2.jpg");


                                var w2 = img2.Width;
                                var h2 = img2.Height;

                                if (w1 != w2 && h1 != h2)
                                {
                                    Console.WriteLine("Размер картинок не совпадает");
                                    return;
                                }

                                using (var img_out3 = new Bitmap(w1, h1))   //создаем пустое изображение размером с исходное для сохранения результата
                                {
                                    var time1 = DateTime.Now;



                                    for (int i = 0; i < h1; ++i)
                                    {
                                        for (int j = 0; j < w1; ++j)
                                        {
                                            var pix1 = img1.GetPixel(j, i);

                                            int r1 = pix1.R;
                                            int g1 = pix1.G;
                                            int b1 = pix1.B;

                                            var pix2 = img2.GetPixel(j, i);

                                            int r2 = pix2.R;
                                            int g2 = pix2.G;
                                            int b2 = pix2.B;

                                            if (r1 + g1 + b1 < r2 + g2 + b2)
                                            {
                                                r1 = r2;
                                                g1 = g2;
                                                b1 = b2;
                                            }

                                            //r1 = Math.Max(r1, r2);
                                            //g1 = Math.Max(g1, g2);
                                            //b1 = Math.Max(b1, b2);

                                            pix1 = Color.FromArgb(r1, g1, b1);
                                            img_out3.SetPixel(j, i, pix1);
                                        }
                                    }

                                    var time2 = DateTime.Now;
                                    Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                    img_out3.Save("..\\..\\out3.jpg");

                                    Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out3.jpg");
                                    //Console.ReadKey();
                                }
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //4. Нарисовать гистограмму x^2
                    #region Нарисовать гистограмму x^2
                    case "4":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {                             
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");

                            var w1 = img1.Width;
                            var h1 = img1.Height;
                            var wh = 256;
                            var hh = 128;
                            double k = 1;

                            int[] N = new int[256];

                            using (var histo_in = new Bitmap(wh, hh))   //создаем пустое изображение размером с исходное для сохранения результата
                            {
                                var time1 = DateTime.Now;

                                var c = 0;
                                var max = 0;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        c = (r1 + g1 + b1) / 3;
                                        N[c]++;
                                    }
                                }

                                for (int i = 0; i < 255; ++i)
                                {
                                    max = Math.Max(max, N[i]);
                                }

                                k = (double)hh / (double)max;

                                using (var graph = Graphics.FromImage(histo_in))
                                {
                                    graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graph.SmoothingMode = SmoothingMode.HighQuality;

                                    var p = Pens.Black.Clone() as Pen;
                                    p.Width = 1;

                                    for (int i = 0; i < 255; ++i)
                                    {
                                        graph.DrawLine(p, i, hh - 1, i, Convert.ToInt32(hh - 1 - N[i] * k));
                                    }
                                    p.Dispose();
                                }

                                var time2 = DateTime.Now;
                                Console.WriteLine("Нарисовал гистограмму за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                histo_in.Save("..\\..\\histo_in.png");

                                Console.WriteLine("Гистограмма была сохренена по пути " + Directory.GetParent("..\\..\\") + "\\histo_in.png");
                                //Console.ReadKey();
                            }

                            using (var img_out4 = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        r1 = (int)(255 * ((double)r1 / 255) * ((double)r1 / 255));
                                        g1 = (int)(255 * ((double)g1 / 255) * ((double)g1 / 255));
                                        b1 = (int)(255 * ((double)b1 / 255) * ((double)b1 / 255));

                                        pix1 = Color.FromArgb(r1, g1, b1);
                                        img_out4.SetPixel(j, i, pix1);

                                        var c = (r1 + g1 + b1) / 3;
                                        N[c]++;
                                    }
                                }
                                var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                img_out4.Save("..\\..\\out4.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out4.jpg");
                                //Console.ReadKey();
                            }

                            using (var histo_out1 = new Bitmap(wh, hh))   //создаем пустое изображение размером с исходное для сохранения результата
                            {
                                var time1 = DateTime.Now;

                                var max = 0;

                                for (int i = 0; i < 255; ++i)
                                {
                                    max = Math.Max(max, N[i]);
                                }

                                k = (double)hh / (double)max;

                                using (var graph = Graphics.FromImage(histo_out1))
                                {
                                    graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graph.SmoothingMode = SmoothingMode.HighQuality;

                                    var p = Pens.Black.Clone() as Pen;
                                    p.Width = 1;

                                    for (int i = 0; i < 255; ++i)
                                    {
                                        graph.DrawLine(p, i, hh - 1, i, Convert.ToInt32(hh - 1 - N[i] * k));
                                    }
                                    p.Dispose();
                                }

                                var time2 = DateTime.Now;
                                Console.WriteLine("Нарисовал гистограмму за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                histo_out1.Save("..\\..\\histo_out1.png");

                                Console.WriteLine("Гистограмма была сохренена по пути " + Directory.GetParent("..\\..\\") + "\\histo_out1.png");
                                //Console.ReadKey();
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //5. Нарисовать гистограмму sqrt(x)
                    #region Нарисовать гистограмму sqrt(x)
                    case "5":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");

                            var w1 = img1.Width;
                            var h1 = img1.Height;
                            var wh = 256;
                            var hh = 128;
                            double k = 1;

                            int[] N = new int[256];

                            using (var histo_in = new Bitmap(wh, hh))   //создаем пустое изображение размером с исходное для сохранения результата
                            {
                                var time1 = DateTime.Now;

                                var c = 0;
                                var max = 0;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        c = (r1 + g1 + b1) / 3;
                                        N[c]++;
                                    }
                                }

                                for (int i = 0; i < 255; ++i)
                                {
                                    max = Math.Max(max, N[i]);
                                }

                                k = (double)hh / (double)max;

                                using (var graph = Graphics.FromImage(histo_in))
                                {
                                    graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graph.SmoothingMode = SmoothingMode.HighQuality;

                                    var p = Pens.Black.Clone() as Pen;
                                    p.Width = 1;

                                    for (int i = 0; i < 255; ++i)
                                    {
                                        graph.DrawLine(p, i, hh - 1, i, Convert.ToInt32(hh - 1 - N[i] * k));
                                    }
                                    p.Dispose();
                                }

                                var time2 = DateTime.Now;
                                Console.WriteLine("Нарисовал гистограмму за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                histo_in.Save("..\\..\\histo_in.png");

                                Console.WriteLine("Гистограмма была сохренена по пути " + Directory.GetParent("..\\..\\") + "\\histo_in.png");
                                //Console.ReadKey();
                            }

                            using (var img_out5 = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        r1 = (int)(255 * Math.Sqrt((double)r1 / 255));
                                        g1 = (int)(255 * Math.Sqrt((double)g1 / 255));
                                        b1 = (int)(255 * Math.Sqrt((double)b1 / 255));

                                        pix1 = Color.FromArgb(r1, g1, b1);
                                        img_out5.SetPixel(j, i, pix1);

                                        var c = (r1 + g1 + b1) / 3;
                                        N[c]++;
                                    }
                                }
                                var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                img_out5.Save("..\\..\\out5.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out5.jpg");
                                //Console.ReadKey();
                            }

                            using (var histo_out2 = new Bitmap(wh, hh))   //создаем пустое изображение размером с исходное для сохранения результата
                            {
                                var time1 = DateTime.Now;

                                var max = 0;

                                for (int i = 0; i < 255; ++i)
                                {
                                    max = Math.Max(max, N[i]);
                                }

                                k = (double)hh / (double)max;

                                using (var graph = Graphics.FromImage(histo_out2))
                                {
                                    graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graph.SmoothingMode = SmoothingMode.HighQuality;

                                    var p = Pens.Black.Clone() as Pen;
                                    p.Width = 1;

                                    for (int i = 0; i < 255; ++i)
                                    {
                                        graph.DrawLine(p, i, hh - 1, i, Convert.ToInt32(hh - 1 - N[i] * k));
                                    }
                                    p.Dispose();
                                }

                                var time2 = DateTime.Now;
                                Console.WriteLine("Нарисовал гистограмму за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                histo_out2.Save("..\\..\\histo_out2.png");

                                Console.WriteLine("Гистограмма была сохренена по пути " + Directory.GetParent("..\\..\\") + "\\histo_out2.png");
                                //Console.ReadKey();
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //6. Бинаризация методом Гарвилова
                    #region Бинаризация методом Гарвилова
                    case "6":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))    //открываем картинку     
                        {
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");


                            var w1 = img1.Width;
                            var h1 = img1.Height;
                            int avg = 0;
                            int n = 0;

                            using (var img_out5 = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        avg += (r1 + g1 + b1) / 3;
                                        n++;
                                    }
                                }
                                var thold = avg / n;

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);

                                        int r1 = pix1.R;
                                        int g1 = pix1.G;
                                        int b1 = pix1.B;

                                        if(((r1 + g1 + b1) / 3) <= thold)
                                        {
                                            pix1 = Color.FromArgb(0, 0, 0);
                                            img_out5.SetPixel(j, i, pix1);
                                        }
                                        else
                                        {
                                            pix1 = Color.FromArgb(255, 255, 255);
                                            img_out5.SetPixel(j, i, pix1);
                                        }
                                    }
                                }


                                var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                img_out5.Save("..\\..\\out6.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out6.jpg");
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //7. Линейный матричный фильтр
                    #region Линейный матричный фильтр
                    case "7":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))
                        {
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");

                            var w1 = img1.Width;
                            var h1 = img1.Height;
                            //double[,] N = new double[3, 3] { { 0.054901, 0.111345, 0.054901 }, { 0.111345, 0.225821, 0.111345 }, { 0.054901, 0.111345, 0.054901 } };        //Размытие
                            double[,] N = new double[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };                                                               //Резкость
                            var div = 1;


                            using (var img_out6 = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;

                                for (int i = 1; i < h1-1; ++i)
                                {
                                    for (int j = 1; j < w1-1; ++j)
                                    {
                                        var r11 = img1.GetPixel(j - 1, i - 1);
                                        var r12 = img1.GetPixel(j - 1, i);
                                        var r13 = img1.GetPixel(j - 1, i + 1);
                                        var r21 = img1.GetPixel(j, i - 1);
                                        var r22 = img1.GetPixel(j, i);
                                        var r23 = img1.GetPixel(j, i + 1);
                                        var r31 = img1.GetPixel(j + 1, i - 1);
                                        var r32 = img1.GetPixel(j + 1, i);
                                        var r33 = img1.GetPixel(j + 1, i + 1);

                                        int r1 = (int)Clamp((N[0, 0] * r11.R + N[0, 1] * r12.R + N[0, 2] * r13.R +
                                                             N[1, 0] * r21.R + N[1, 1] * r22.R + N[1, 2] * r23.R +
                                                             N[2, 0] * r31.R + N[2, 1] * r32.R + N[2, 2] * r33.R) * 1 / div, 0, 255);

                                        int g1 = (int)Clamp((N[0, 0] * r11.G + N[0, 1] * r12.G + N[0, 2] * r13.G +
                                                             N[1, 0] * r21.G + N[1, 1] * r22.G + N[1, 2] * r23.G +
                                                             N[2, 0] * r31.G + N[2, 1] * r32.G + N[2, 2] * r33.G) * 1 / div, 0, 255);

                                        int b1 = (int)Clamp((N[0, 0] * r11.B + N[0, 1] * r12.B + N[0, 2] * r13.B +
                                                             N[1, 0] * r21.B + N[1, 1] * r22.B + N[1, 2] * r23.B +
                                                             N[2, 0] * r31.B + N[2, 1] * r32.B + N[2, 2] * r33.B) * 1 / div, 0, 255);
                                        var pix1 = Color.FromArgb(r1, g1, b1);
                                        img_out6.SetPixel(j, i, pix1);
                                    }
                                }

                                var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                img_out6.Save("..\\..\\out6.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out6.jpg");
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //8. Медианный матричный фильтр
                    #region Медианный матричный фильтр
                    case "8":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))
                        {
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");

                            var w1 = img1.Width;
                            var h1 = img1.Height;

                            using (var img_out7 = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;

                                for(int x = 1; x < w1 - 1; x++)
                                {
                                    for(int y = 1; y <h1 - 1; y++)
                                    {
                                        int n;
                                        int cR_, cB_, cG_;
                                        int k = 1;
                                        int rad = 1;

                                        n = (2 * rad + 1) * (2 * rad + 1);

                                        int[] cR = new int[n + 1];
                                        int[] cB = new int[n + 1];
                                        int[] cG = new int[n + 1];

                                        for (int i = 0; i < n + 1; i++)
                                        {
                                            cR[i] = 0;
                                            cG[i] = 0;
                                            cB[i] = 0;
                                        }

                                        for (int i = x - rad; i < x + rad + 1; i++)
                                        {
                                            for (int j = y - rad; j < y + rad + 1; j++)
                                            {
                                                if (i < w1 && j < h1 && i > 0 && j > 0)
                                                {
                                                    System.Drawing.Color c = img1.GetPixel(i, j);
                                                    cR[k] = System.Convert.ToInt32(c.R);
                                                    cG[k] = System.Convert.ToInt32(c.G);
                                                    cB[k] = System.Convert.ToInt32(c.B);
                                                    k++;
                                                }
                                            }
                                        }

                                        QSort.QuickSort(cR, 0, n - 1);
                                        QSort.QuickSort(cG, 0, n - 1);
                                        QSort.QuickSort(cB, 0, n - 1);

                                        int n_ = (int)(n / 2) + 1;

                                        cR_ = cR[n_];
                                        cG_ = cG[n_];
                                        cB_ = cB[n_];

                                        img_out7.SetPixel(x, y, System.Drawing.Color.FromArgb(cR_, cG_, cB_));
                                    }
                                }

                            var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                img_out7.Save("..\\..\\out7.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\out7.jpg");
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    //9. Фурье преобразование (WIP)
                    #region Фурье преобразование
                    case "9":
                        using (var img1 = new Bitmap("..\\..\\in1.jpg"))
                        {
                            Console.WriteLine("Открываю первое изображение " + Directory.GetParent("..\\..\\") + "\\in1.jpg");

                            var w1 = img1.Width;
                            var h1 = img1.Height;
                           
                            using (var fourier = new Bitmap(w1, h1))
                            {
                                var time1 = DateTime.Now;
                                float[] r = new float[w1];
                                float[] g = new float[w1];
                                float[] b = new float[w1];
                                Complex[,] Ir = new Complex[h1, w1];
                                Complex[,] Ig = new Complex[h1, w1];
                                Complex[,] Ib = new Complex[h1, w1];

                                Complex[] Yr = new Complex[h1];
                                Complex[] Yg = new Complex[h1];
                                Complex[] Yb = new Complex[h1];

                                for (int i = 0; i < h1; ++i)
                                {
                                    for (int j = 0; j < w1; ++j)
                                    {
                                        var pix1 = img1.GetPixel(j, i);
                                        r[i] = pix1.R;
                                        g[i] = pix1.G;
                                        b[i] = pix1.B;
                                    }
                                                                      
                                    var Xr = r.Select(x => (Complex)x).ToArray();
                                    var Xg = g.Select(x => (Complex)x).ToArray();
                                    var Xb = b.Select(x => (Complex)x).ToArray();
                                    var Gr = fft(Xr);
                                    var Gg = fft(Xg);
                                    var Gb = fft(Xb);
                                    for (int j = 0; j < w1; j++)
                                    {
                                        Ir[i, j] = Gr[j];
                                        Ig[i, j] = Gg[j];
                                        Ib[i, j] = Gb[j];
                                    }

                                }
                                for (int j = 0; j < w1; ++j)
                                {
                                    for (int i = 0; i < h1; ++i)
                                    {
                                        Yr[i] = Ir[i, j];
                                        Yg[i] = Ig[i, j];
                                        Yb[i] = Ib[i, j];
                                    }
                                    var Hr = fft(Yr);
                                    var Hg = fft(Yg);
                                    var Hb = fft(Yb);
                                    Hr = nfft(Hr);
                                    Hg = nfft(Hg);
                                    Hb = nfft(Hb);
                                    for (int i = 0; i < h1; i++)
                                    {
                                        Ir[i, j] = Hr[i];
                                        Ig[i, j] = Hg[i];
                                        Ib[i, j] = Hb[i];
                                    }

                                }
                                for(int j = 0; j < w1; ++j)
                                {
                                    for (int i = 0; i < h1; ++i)
                                    {
                                        var r_c = (int)Clamp(Ir[i, j].Magnitude, 0, 255);
                                        var g_c = (int)Clamp(Ig[i, j].Magnitude, 0, 255);
                                        var b_c = (int)Clamp(Ib[i, j].Magnitude, 0, 255);
                                        var pix1 = Color.FromArgb(r_c, g_c, b_c);
                                        fourier.SetPixel(j, i, pix1);
                                    }
                                }
                                

                                var time2 = DateTime.Now;
                                Console.WriteLine("Обработал изображение за " + Math.Round((time2 - time1).TotalMilliseconds) + " мс.");

                                fourier.Save("..\\..\\fourier.jpg");

                                Console.WriteLine("Выходное изображение было сохренено по пути " + Directory.GetParent("..\\..\\") + "\\fourier.jpg");
                            }
                        }
                        caseSwitch = Console.ReadLine();
                        break;
                    #endregion

                    default: return;
                }
            } while (caseSwitch != "10");
        }






        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static Complex w(int k, int N)
        {
            if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        public static Complex[] fft(Complex[] x)
        {
            Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                Complex[] X_even = fft(x_even);
                Complex[] X_odd = fft(x_odd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + w(i, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - w(i, N) * X_odd[i];
                }
            }
            return X;
        }
        public static Complex[] nfft(Complex[] X)
        {
            int N = X.Length;
            Complex[] X_n = new Complex[N];
            for (int i = 0; i < N / 2; i++)
            {
                X_n[i] = X[N / 2 + i];
                X_n[N / 2 + i] = X[i];
            }
            return X_n;
        }
    }


}
