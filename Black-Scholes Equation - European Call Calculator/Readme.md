# Black-Scholes Equation - European Call Calculator
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Forms
- Visual C#
- Visual Studio 2015
## Topics
- Numerical Computing
- Visual C#
- Cumulative Distribution Function
- Black-Scholes Equation
- European Call
## Updated
- 07/31/2017
## Description

<h1>Introduction</h1>
<p><em>The Black-Scholes Equation is used in finance to calculate stock options. This particular application deals with the Europeon call stock option. By a transformation of variables the Black-Scholes partial differential equation can be reduced to a one
 dimensional diffusion problem and in the general case solved numerically.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This application should build as is using Visual Studio 2015 Professional.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This is a European call stock option calculator modelled on the website:&nbsp;http://www.money-zine.com/calculators/investment-calculators/black-scholes-calculator/. The necessary equations can be found on the webpage:&nbsp;http://finance.bi.no/~bernt/gcc_prog/algoritms_v1/algoritms/node8.html.
 For the Europeon call stock option case an analytic solution exists. In other cases one has to settle for numerical approximations using the finite difference methods such as the Crank-Nicolson method.</em></p>
<p><em><img id="176350" width="384" height="361" src="176350-mainform%207_31_2017%2010_01_16%20pm.png" alt=""><img id="176351" width="384" height="361" src="176351-mainform%207_31_2017%2010_01_26%20pm.png" alt="">&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;

namespace BlackScholesEquation
{
    class EuropeanCall
    {
        private double N, sigma2;
        private double d1, d2, deltaT, sd;
        private double phi1, phi2, phi3, phi4;
        private double p1, p2;

        // Translated from Pascal code found in Wikipedia article
        // https://en.wikipedia.org/wiki/Normal_distribution#Cumulative_distribution_function

        private double CDF(double x)
        {
            double sum = x, val = x;

            for (int i = 1; i &lt;= 100; i&#43;&#43;)
            {
                val *= x * x / (2.0 * i &#43; 1.0);
                sum &#43;= val;
            }

            return 0.5 &#43; (sum / Math.Sqrt(2.0 * Math.PI)) * Math.Exp(-(x * x) / 2.0);
        }

        public EuropeanCall(double S, double X, double r,
            double sigma, double t, double T, out double c, out double p)
        {
            // S = underlying asset price (stock price)
            // X = exercise price
            // r = risk free interst rate
            // sigma = standard deviation of underlying asset (stock)
            // t = current date
            // T = maturity date

            sigma2 = sigma * sigma;
            deltaT = T - t;
            N = 1.0 / Math.Sqrt(2.0 * Math.PI * sigma2);
            sd = Math.Sqrt(deltaT);
            d1 = (Math.Log(S / X) &#43; (r &#43; 0.5 * sigma2) * deltaT) / (sigma * sd);
            d2 = d1 - sigma * sd;
            phi1 = CDF(d1);
            phi2 = CDF(d2);
            phi3 = CDF(-d2);
            phi4 = CDF(-d1);
            c = S * phi1 - X * Math.Exp(-r * deltaT) * phi2;
            p = X * Math.Exp(-r * deltaT) * phi3 - S * phi4;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BlackScholesEquation&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;EuropeanCall&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;N,&nbsp;sigma2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;d1,&nbsp;d2,&nbsp;deltaT,&nbsp;sd;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;phi1,&nbsp;phi2,&nbsp;phi3,&nbsp;phi4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;p1,&nbsp;p2;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Translated&nbsp;from&nbsp;Pascal&nbsp;code&nbsp;found&nbsp;in&nbsp;Wikipedia&nbsp;article</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;https://en.wikipedia.org/wiki/Normal_distribution#Cumulative_distribution_function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;CDF(<span class="cs__keyword">double</span>&nbsp;x)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;sum&nbsp;=&nbsp;x,&nbsp;val&nbsp;=&nbsp;x;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;<span class="cs__number">100</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val&nbsp;*=&nbsp;x&nbsp;*&nbsp;x&nbsp;/&nbsp;(<span class="cs__number">2.0</span>&nbsp;*&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__number">1.0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;&#43;=&nbsp;val;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__number">0.5</span>&nbsp;&#43;&nbsp;(sum&nbsp;/&nbsp;Math.Sqrt(<span class="cs__number">2.0</span>&nbsp;*&nbsp;Math.PI))&nbsp;*&nbsp;Math.Exp(-(x&nbsp;*&nbsp;x)&nbsp;/&nbsp;<span class="cs__number">2.0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;EuropeanCall(<span class="cs__keyword">double</span>&nbsp;S,&nbsp;<span class="cs__keyword">double</span>&nbsp;X,&nbsp;<span class="cs__keyword">double</span>&nbsp;r,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;sigma,&nbsp;<span class="cs__keyword">double</span>&nbsp;t,&nbsp;<span class="cs__keyword">double</span>&nbsp;T,&nbsp;<span class="cs__keyword">out</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;c,&nbsp;<span class="cs__keyword">out</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;p)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;S&nbsp;=&nbsp;underlying&nbsp;asset&nbsp;price&nbsp;(stock&nbsp;price)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;X&nbsp;=&nbsp;exercise&nbsp;price</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;r&nbsp;=&nbsp;risk&nbsp;free&nbsp;interst&nbsp;rate</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;sigma&nbsp;=&nbsp;standard&nbsp;deviation&nbsp;of&nbsp;underlying&nbsp;asset&nbsp;(stock)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;t&nbsp;=&nbsp;current&nbsp;date</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;T&nbsp;=&nbsp;maturity&nbsp;date</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sigma2&nbsp;=&nbsp;sigma&nbsp;*&nbsp;sigma;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;deltaT&nbsp;=&nbsp;T&nbsp;-&nbsp;t;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;N&nbsp;=&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;Math.Sqrt(<span class="cs__number">2.0</span>&nbsp;*&nbsp;Math.PI&nbsp;*&nbsp;sigma2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sd&nbsp;=&nbsp;Math.Sqrt(deltaT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d1&nbsp;=&nbsp;(Math.Log(S&nbsp;/&nbsp;X)&nbsp;&#43;&nbsp;(r&nbsp;&#43;&nbsp;<span class="cs__number">0.5</span>&nbsp;*&nbsp;sigma2)&nbsp;*&nbsp;deltaT)&nbsp;/&nbsp;(sigma&nbsp;*&nbsp;sd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d2&nbsp;=&nbsp;d1&nbsp;-&nbsp;sigma&nbsp;*&nbsp;sd;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phi1&nbsp;=&nbsp;CDF(d1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phi2&nbsp;=&nbsp;CDF(d2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phi3&nbsp;=&nbsp;CDF(-d2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phi4&nbsp;=&nbsp;CDF(-d1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c&nbsp;=&nbsp;S&nbsp;*&nbsp;phi1&nbsp;-&nbsp;X&nbsp;*&nbsp;Math.Exp(-r&nbsp;*&nbsp;deltaT)&nbsp;*&nbsp;phi2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p&nbsp;=&nbsp;X&nbsp;*&nbsp;Math.Exp(-r&nbsp;*&nbsp;deltaT)&nbsp;*&nbsp;phi3&nbsp;-&nbsp;S&nbsp;*&nbsp;phi4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainForm.cs - the main and only form of the application.</em> </li><li><em>EuropeonCall.cs </em><em><em>- where the calculations are performed.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on Black-Scholes equation and the related diffusion equation, see the many good webpages to be found via Bing or Google.</em></p>
