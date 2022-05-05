using System;
using System.Linq;

namespace FLibCore.Generation
{
	public class WordGenerator
	{
		private static Random random = new Random(Convert.ToInt32(DateTime.Now.Ticks));
		
		// TODO: Drive this with JSON.
		private static string[] consonants = "b,c,d,f,g,h,j,k,l,m,n,p,r,s,t,v,w,x,y,z,pt,gl,gr,ch,ph,s,sh,st,th,wh".Split(',');
		private static string[] nostart_consonants = "ck,cm,dr,ds,ft,gh,gn,kr,ks,ls,lt,lr,mp,mt,ms,ng,ns,rd,rg,rs,rt,ss,ts,tch,yy".Split(',');
		private static string[] vowels = "a,e,i,o,u,y,ee,oa,oo".Split(',');

		public string GeneratePronounceable(int length = 8)
		{
			var current = Convert.ToBoolean(random.Next(0, 1)) ? "cons" : "vows";

			var result = string.Empty;

			while (result.Length < length)
			{

			}

			return result;
		}
	}
}
