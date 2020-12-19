﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdventOfCode.Day06
{
    public static class Main
    {
        public static void Run()
        {
            var anyAnswers = data.Select(GroupAnswersAny).Select(s => s.Length).Aggregate((a,b) => a+b);
            Console.WriteLine($"There are {anyAnswers} 'any' answers across all groups");

            var allAnswers = data.Select(GroupAnswersAll).Select(s => s.Length).Aggregate((a, b) => a + b);
            Console.WriteLine($"There are {allAnswers} 'all' answers across all groups");
        }

        private static string GroupAnswersAny(List<string> group)
        {
            return String.Concat(group.Aggregate((a, b) => a + b).ToList().Distinct());
        }
        private static string GroupAnswersAll(List<string> group)
        {
            return group.Aggregate((a, b) =>
            {
                var c = "";
                foreach (var i in a.ToList())
                {
                    if (b.Contains(i))
                        c += i;
                }

                return c;
            });
        }

        private static List<List<string>> data = new List<List<string>>
        {
            new List<string> {"v", "vx", "v", "vx", "nclmbv"},
            new List<string> {"odgpnwqxhbits", "pqwsnxihogdbt", "pogiwxdhqbsnt"},
            new List<string> {"q", "o"},
            new List<string> {"apulnqresohvktxcymzibdwg", "sigdvakmlyxhetopnubwzrqc", "iushndtclbeyowxpqmkgzavr"},
            new List<string> {"ow", "wo"},
            new List<string> {"phegq", "eqgph", "hgpque"},
            new List<string> {"xispjzq", "sqkzcupi", "ikspqyzue"},
            new List<string> {"hgfesyvn", "dnsvtkhglea", "heygnqbcvs"},
            new List<string> {"qmrpy", "pmrck", "vcprum", "mrkcp", "mrp"},
            new List<string> {"kgjx", "jghk", "kjgu", "enlgdwzqkjr", "vjgk"},
            new List<string> {"ungsdozkphlxy", "nbkgzaifsovjpdt", "geoskuyznpcd"},
            new List<string> {"qw", "qw"},
            new List<string> {"x", "r", "sl", "v", "s"},
            new List<string> {"kxcn", "kxn", "wxtkn", "xkcn", "xkn"},
            new List<string> {"peionmzqyda", "apdinomqzey", "npmqoiedzay", "dmpzoyqiane"},
            new List<string> {"gpaedw", "mwda", "daw", "awbd"},
            new List<string> {"fyxeptlrmisjhdzquv", "xfqydzruvmjepsilth", "sipulvdzmftqeyhrxj"},
            new List<string> {"kzofrcamenxyvwgpq", "zqkrapxwomvycgnef", "ywxvpazgcenrqkfmo", "kgcvezmfqwrpnxaoy"},
            new List<string> {"zhf", "zegfhd", "fhz", "hfz"},
            new List<string> {"iqspn", "bytmd", "sq", "gwx"},
            new List<string> {"begosk", "gnbskz", "sgkb"},
            new List<string> {"ok", "ek", "ek", "k"},
            new List<string> {"hbucsatqvdryfojxlz", "tufzxjvbrwasemg"},
            new List<string> {"d", "ef", "k"},
            new List<string> {"p", "mrp"},
            new List<string> {"kuywroetvjnf", "wjvtkreufyn", "frkyjwevntu", "frtewnkjvuy"},
            new List<string> {"iu", "wzi", "axbcgpldyi", "seoiz"},
            new List<string> {"ekjmbsuwglftpvya", "esmwuftgpvyjalkb", "vflbtyekmjupasgw", "tepmwgksulybavjf", "psawvbtgjfelmyuk"},
            new List<string> {"jsmoydnvkiql", "lqdojsvnik"},
            new List<string> {"ayrtxivjlpeuzohnk", "whjitnkfyealoguxprzc", "bzjiruohtlakxnedypm", "pmyxeizqjhkntoarul"},
            new List<string> {"vnrcwouidfb", "bufrwnociv", "unrvefbcwo", "cvnswubfro"},
            new List<string> {"hmnoazwvtcrigqsujldpk", "qeflzdwyongvtjishpacumr"},
            new List<string> {"ytwpgkvceaolhrz", "agyepkhwlzvctr", "yvpkwcgerzhtaq", "pcaeygktzwhrv", "rgvpkwtylzhcea"},
            new List<string> {"io", "oi", "io", "ito"},
            new List<string> {"ckmfawyb", "glvfiymobadc", "jnsfbmapcy", "jfysmathnbc"},
            new List<string> {"uxbfdygqwpom", "sxmuwbdporyvqh", "rbuqmwxydpo", "ncpuyowqildjxebmk", "wxuysoqhvbampd"},
            new List<string> {"keo", "oz", "jdorxbia", "lo", "ok"},
            new List<string> {"zk", "zco"},
            new List<string> {"bhwmscnrqeou", "rlqenzswohbmu"},
            new List<string> {"synmfzljkdebq", "cmdyzlfekjbns", "nkgzsmvlydpjobfute", "lsfjkmnzdeby"},
            new List<string> {"xshlzwcndtjefi", "wcnljfditsexzh", "ehtsjwidflcznx"},
            new List<string> {"zry", "vyqz"},
            new List<string> {"owfcybsdipnqlthavu", "psdiqfhwctrzvaybon", "ybmpdciqhvtsfawon", "givjcetkhwbdyponfsaq", "cvotsnhqfywplidab"},
            new List<string> {"cibwptjnu", "ncruhi", "hnuic"},
            new List<string> {"apzjqbdlwyicfgxv", "apxodvwlzyfbgqcij", "pcdxjvzwqfliyagb", "rixjaclsdpvyzgwqmbfe"},
            new List<string> {"timpsox", "poxsm"},
            new List<string> {"fres", "refs", "fersq"},
            new List<string> {"w", "z", "r", "w", "r"},
            new List<string> {"xz", "x", "x", "x"},
            new List<string> {"ciyhkpjswqvxz", "xyskvphmowjzcia", "kywsxihpc", "wtpnflcsekhbgxud"},
            new List<string> {"qrtweigjlbucfxnkos", "iwlbgmnosuxfetkrqc", "sfbwxcotierqukldn", "euroqfdxywclsitkbn", "qelfbarchnwuxtsiok"},
            new List<string> {"gj", "woh", "g", "jr"},
            new List<string> {"lpcdqf", "qdfupwzcl", "dpcqgtl"},
            new List<string> {"zlnkeyroq", "rtyoleqnkz", "leykztqnor", "ahoukcelrxjqynpz"},
            new List<string> {"twxjdbuhclzgnop", "fgeqkcbvziwtludop"},
            new List<string> {"ylukhwtcf", "aikdrxfov"},
            new List<string> {"ucbklojiyxmz", "ulkjco", "kroljuch"},
            new List<string> {"rfhyj", "fhy"},
            new List<string> {"cmtedvxioy", "infmacweshtuo", "tpoimecz"},
            new List<string> {"kylduhw", "yublkhd", "kdulyh", "dyuhlrk", "zhfgkudly"},
            new List<string> {"laoemdcgpyhtnb", "ygclebodtmpnha", "zomgnqpalhebxwtcd"},
            new List<string> {"bmogrnztvyil", "vlotrzngbmiy", "lvyogrzbimtn"},
            new List<string> {"zjcgheblotdramsn", "mlgbshrzotcnjawd", "otgsjdnmbrchlza", "dbazlpfkhgtmsvocnjqr", "sgrazcjondmlhbt"},
            new List<string> {"ryhifaxpemsgcdubvtjzwnol", "bduiojqhcsvlyrxefntpgwma", "pvebfwitculrgyjshkdxmaon"},
            new List<string> {"lqmopgwbesjhk", "mgbkhqejlswop", "wqklaeogsdxhfbmjp", "sjgphokmqewlb", "kesrghbmpjlowq"},
            new List<string> {"tu", "rp", "r", "rgh"},
            new List<string> {"tfeyhjbnpaqwz", "rxuefvgiaybzqth"},
            new List<string> {"pwx", "lk", "iahyv", "jr", "p"},
            new List<string> {"ezsghqtdnjbfox", "dsucq", "sduqp", "cusvdqy", "dslwqm"},
            new List<string> {"dm", "gf", "g", "xtg"},
            new List<string> {"mfihn", "mhyifot"},
            new List<string> {"iabeswqrzlcxvkpmtnug", "qexctgrkwbpusazinmv", "riztmgqsewunxbapkcvj", "avbuxqizmrkeswtpncg"},
            new List<string> {"ozrwipdmgajlkfuxcnhtyveqs", "fntcigalzdxmyuesjkqwo", "dtfyeqklgjmwxunosizca", "efclkowaujqzigbtymdxsn"},
            new List<string> {"jkiupmatwxqhdrs", "midjhwutq", "dmhujzqwyit", "dwuqhymtji"},
            new List<string> {"ziqfh", "hnboqe", "qhktzdfp"},
            new List<string> {"qohbywgtlucajf", "ltahuywfjbmc"},
            new List<string> {"arfpqdcbtnw", "kfzonycewxbghvr"},
            new List<string> {"tdxqelwnu", "luenxdtqw", "udlteqxnw", "wxendqlut"},
            new List<string> {"pvkrgaushqidfmnjz", "eajzrkhndfitsqvmwugyp", "sgohxqcvrzunapjfdmki", "vinodpkazgfrmcushjq", "jmufirnszpdqoahgkv"},
            new List<string> {"uvcmgfrk", "fugmrvck", "kfuvrmcg", "cmrfgkuv", "kcvumfgr"},
            new List<string> {"kmrb", "krbm", "rkb", "bekrt", "rbmk"},
            new List<string> {"mzbrfsnxgjpywavcohuqlkitde", "xpekistdzlrgmcawnvuqfohjby"},
            new List<string> {"vrjew", "rvj"},
            new List<string> {"qlefnd", "fdleo", "pxcehwdfy"},
            new List<string> {"amftbpvo"},
            new List<string> {"ljcyn", "cynosjum", "jync", "yrqbwjzc", "jcy"},
            new List<string> {"tmdcuk", "ckudm", "mucdk", "cdkum"},
            new List<string> {"icsvhmefaztoxkgndq", "sbyqivkrdplwjemou"},
            new List<string> {"jtrhafpkbwzdox", "hbrwpzajokfx", "jbkfaphxzcrwon"},
            new List<string> {"bqg", "qgb", "bgq", "qbg", "qgb"},
            new List<string> {"ljte", "jle"},
            new List<string> {"tvhjx", "hvjwxrt", "vtjxh", "dtjvhx", "vjxht"},
            new List<string> {"zsdejcrvab", "kbjzrscaedv"},
            new List<string> {"oehivmku", "igfhuxozy"},
            new List<string> {"x", "xs", "x", "x", "x"},
            new List<string> {"klqnrzftv", "iqgfaupt", "fdqgswyjt"},
            new List<string> {"opjeslcx", "psohecjxl", "yxelsjoc", "lescojvx", "molnextcsj"},
            new List<string> {"sf", "cps", "fos"},
            new List<string> {"crxbjzkivydsgfpehmq", "wnhfgljeptzrmikcy"},
            new List<string> {"bghydvqxicsfunlzpart", "rsyugqcxtvdzanpblihf"},
            new List<string> {"v", "gnvw", "lv", "v", "lv"},
            new List<string> {"mpzvdjqhxnuocr", "chidrnuvxmkjqpt", "suhdxgvbcnrpmj"},
            new List<string> {"ewpfugobznrqydsj", "ivgxtjludcm"},
            new List<string> {"enytuvzoqmljfwd", "satbgwcrndzyk"},
            new List<string> {"fuzl", "ful", "lu", "lpuxy"},
            new List<string> {"qrhltkesazpmo", "puaedmzsqhot"},
            new List<string> {"vcktz", "zqtjsbuiaomwf", "ygzkthx"},
            new List<string> {"zt", "tdz"},
            new List<string> {"fvpjlcarqdukio", "luotiqzkjfrwahcdvm", "rcykufoadqxilvj"},
            new List<string> {"kfpuwxi", "wpfxuik"},
            new List<string> {"xjzpf", "cyqsouwf", "xzf", "zf", "bifpj"},
            new List<string> {"q", "cw", "n", "nu", "q"},
            new List<string> {"lscdtzvhajkqpm", "vdpklhqscm", "pvcdqskljh", "hcjdqklsyvp", "eqshcdklvp"},
            new List<string> {"muyldxobakfq", "ecjvfm"},
            new List<string> {"jkas", "ws", "s", "ws"},
            new List<string> {"qbjzcolnuy", "jyulobzncq", "izqlnycoubj"},
            new List<string> {"yvsoztedn", "eotvydz", "yzetodv", "edvoyczt"},
            new List<string> {"tcfqkxrib", "fozbtnlwucq", "qvagfdebtc", "qcpftbk"},
            new List<string> {"amlcyk", "acempy", "aymcv", "cayml"},
            new List<string> {"gsybwf", "ybsfgw", "bsgywf", "bfwygs", "fsygbw"},
            new List<string> {"hypxicwobt", "pciytbxwh", "xhycspitbw", "pcibytrhxw", "yckhxtebwpi"},
            new List<string> {"olneqtcpzfiahbj", "oitbqejcahpnfmzl", "bpnjyhfkqmlczteoai", "hlpjefoaqznbtci", "jdwtzsfcviaqnobhpxel"},
            new List<string> {"mkflqourwyh", "kqmylohfu", "lyohqumfk", "fyhukomplq"},
            new List<string> {"cfegzaprw", "prvbgiymj"},
            new List<string> {"besuka", "hsnkua", "slaguxky"},
            new List<string> {"smwuovdpnjfyl", "mcjvguors", "qjvsmiou", "abotmkxujvs", "uhmoqsvje"},
            new List<string> {"udrmcxqay", "dqyhumca", "mfwcujskglbedqt"},
            new List<string> {"xewpyrsjzktgbaochuni", "xjaohuwligysztekpnc", "tfghodxyjsnapmquwcziekv"},
            new List<string> {"fxypwlo", "wpsxleyfo", "ylmpxfzwo"},
            new List<string> {"ok", "rspbkt", "mauyxcw", "rqdkz"},
            new List<string> {"fsehripoyjawt", "styheviwfrn"},
            new List<string> {"onxrvplyuzqcj", "vlzuyrcpxoqjn", "nuoqyrzjcpvxl", "ljyuoqvnzprcx"},
            new List<string> {"o", "ac", "c", "c"},
            new List<string> {"hwxmesjuzo", "hylvoxzpfbntsr", "shoquzx"},
            new List<string> {"pidfxg", "igrxm"},
            new List<string> {"gshkfbcujpyztoevxdlmaw", "kzvmejbygdpaxufhlcotws", "hfgamkstbwjoyxlczupevd"},
            new List<string> {"p", "p", "ltf"},
            new List<string> {"iufdzosnagkhtw", "dzkhlgvsitucoa", "adtgzokhsviuc"},
            new List<string> {"jywe", "wy", "yw", "wzy", "yw"},
            new List<string> {"ghvadykiscnfxo", "noxckgivyhdaf", "gfxmtodbwvnkhipaqy"},
            new List<string> {"ifsp", "xnivluaq", "fioe", "wisydc", "siw"},
            new List<string> {"jxbmclnevwztqug", "keptqcrmzufglhi", "tleqgyvjbumzdc", "xzdmslqcutge"},
            new List<string> {"ogdxpnjbti", "ipgnotx", "ipehgonkcxrtfa", "ntdiygpox"},
            new List<string> {"wxhcjtredknifvulymp", "vgksmwqzctybidjofha"},
            new List<string> {"lxmficysbt", "jslmrn"},
            new List<string> {"pcoxigrdtkul", "sjmhtbxulyord", "uxlcpdktoarv"},
            new List<string> {"crgundohktjfasebzvxl", "gdsvcufrnljazotkxehb", "onbgcjfeirxkhzvudtsla", "njcheafbokgzvsxrudlt", "ekgvfruchstjldoxzabn"},
            new List<string> {"wmkivpgfqdrsl", "wmcjvofkhnz", "kfwbuvam", "jtmwhfkvz"},
            new List<string> {"thy", "hy", "yhe", "yh", "dqbyh"},
            new List<string> {"xtbhkovsjcga", "xqkoeavjsch", "xacvkjhds", "mcjuwskavnrixyh"},
            new List<string> {"lhfwqr", "ypkruwqs", "xcgdwmj"},
            new List<string> {"eyiwrundqsflgcavxk", "fejmwtyulodkhrzbp"},
            new List<string> {"yvz", "expa"},
            new List<string> {"aohj", "ejoai", "ldypfnejoa", "dcxpjoatv"},
            new List<string> {"vuinj", "prv", "v", "vlr"},
            new List<string> {"sqpdmrnlwa", "nlgasrpqomd", "padlqsmrn"},
            new List<string> {"r", "pjd", "d", "azbhs"},
            new List<string> {"hfotieypnlwdkjzv", "jlfveimtdckongwzpy"},
            new List<string> {"af", "zaf", "afn", "abf"},
            new List<string> {"csjx", "scrk", "ucws", "csj", "sjc"},
            new List<string> {"juwtder", "dtjrwe", "werjdt", "djreywut", "rceoqjwdt"},
            new List<string> {"nazufjeomxpkc", "xmeopajcunkzf", "pfcuazejknmxo", "nkzceomfapxju"},
            new List<string> {"epiykxforjz", "fylzbxjeoipg", "ahfyxvpmsujiedzon", "eoyxcqwpikjzfg"},
            new List<string> {"umfrlqhakzdn", "mshjfdkqungrzv"},
            new List<string> {"opxjdgemsvailruzfbcq", "ozmgbdirxelyfsqpjvuc", "iqbucpflxsvzdoetjrm", "ysiqolmberzvjnctdxgufp", "bxfemdhcukplzrijsqvo"},
            new List<string> {"yocg", "g", "uqg", "rzy", "vjbmw"},
            new List<string> {"vljzumo", "ujzvmo", "vujomz", "vjzomu", "zmjuov"},
            new List<string> {"srwagukx", "ahjroqmxy"},
            new List<string> {"cgkj", "jcgknvs", "jgkyc", "kcjgy", "jrgck"},
            new List<string> {"ugcwvx", "gfuzaxw"},
            new List<string> {"n", "o", "n", "n", "n"},
            new List<string> {"vsmd", "mcdvbs", "cdmxy", "tadr"},
            new List<string> {"znsokugwejfylica", "iwpnfyolqzkcuaegdsj"},
            new List<string> {"azuver", "remzau", "arezu", "zerau"},
            new List<string> {"wevbmlq", "bwalcodevx", "ewtuxlbv", "zivypeswlb", "ebwvaln"},
            new List<string> {"qjrdgxmc", "hrcozqdxj"},
            new List<string> {"mpcogjzyrhisuxlv", "mskpazxdfvqc"},
            new List<string> {"xtzyl", "lxyt", "xytl", "xlyt", "oxslyt"},
            new List<string> {"jrteqswkcazlbfhog", "tsqafcbgrelzokhjw"},
            new List<string> {"fjqlibpwukcoznavyrtd", "bzdtupklrqivanwyojfc", "lvjarpkyubndzqiwoftc", "bdrcniwvktylpajoqzuf", "uycprvalqdiwonbjztkf"},
            new List<string> {"lwga", "dgswz", "zgwy", "nwugcrik", "gwsy"},
            new List<string> {"gwmvxakicou", "avugcmowixk", "ckxugomwvia", "ukwacxogmiv", "xiwavcgmkou"},
            new List<string> {"znvgeymhb", "rztconyiq", "lwzayn", "jswnuzyk", "fnwuxlypz"},
            new List<string> {"etkdwlgscmzyuafvhbo", "vhctfgkmwouaylesbzd", "vfcetldzsyobghmuwka", "tsgzmkufeajlvwcyodbh", "gazdhmkotswlfuvbcey"},
            new List<string> {"zdsjweg", "sezjgd", "dsgzei"},
            new List<string> {"zi", "z"},
            new List<string> {"tbg", "fbtg"},
            new List<string> {"g", "g", "g", "g"},
            new List<string> {"rid", "jvi", "inxo", "id"},
            new List<string> {"dbrjtfupcyvzlqmwei", "zqbwfmljvcdirtyepu"},
            new List<string> {"jmhubvclsdprw", "cpswbmldjrveu", "rpbsvucmdfjlw"},
            new List<string> {"qk", "ekniz"},
            new List<string> {"kvlmhegzcryd", "zrlmdgvefyhc", "zhgvrqueymdca", "remdfyhzcgv"},
            new List<string> {"zxhiaqs", "hxiqsa"},
            new List<string> {"sumrbd", "qgrbuw", "ubqgr"},
            new List<string> {"dkmqsebjznylwucxot", "ewyqhjrlpcfotbis"},
            new List<string> {"ti", "kxi"},
            new List<string> {"dvgmlyepfnhscui", "isbvmudynplf", "nzqldwmfyuvtpi", "finlydpourvme", "dulnypvsrafmik"},
            new List<string> {"zemctnsralu", "trnaelzmsuc", "azrstumnecl", "mltrceasnuz", "rtazlucenms"},
            new List<string> {"aydgxnwehomujpv", "nedjuaxhopwvmg", "dvgwhfojpanmuxe", "wjaenpdvmohugx", "vanuomdxjehgwp"},
            new List<string> {"xchjblnwmogv", "coxlngbwjmhv", "mjbwoclgxvnh"},
            new List<string> {"br", "rohb"},
            new List<string> {"knpclsvozb", "slcvbznk", "klcbnvzs", "lsvbkncz"},
            new List<string> {"cehpgtzmawkjndufrlixb", "anrtxfdbhiwmcjzplkeug", "rkmwtcunzxhjpgbafdeil"},
            new List<string> {"rqlstcwxkmoz", "thsvxzkueymrlqw", "rqlskomwzpaxt", "wcxrzmptqkls"},
            new List<string> {"tshv", "hfzdlpij", "hmces"},
            new List<string> {"kfjmaedcoqltuwp", "jrngliqdohsce", "bgclzdhjqxyero"},
            new List<string> {"urndaqxz", "fyw", "wzqua", "ehglomjvbk"},
            new List<string> {"guhfvqlnkydpiz", "ljgyoiqarzksuwet"},
            new List<string> {"yutebcorzh", "slxcdkqnhjga"},
            new List<string> {"fivxqukh", "kixqzvu", "vqxuki", "xnpiuqvk", "kvqfxudie"},
            new List<string> {"rpsfdkmc", "cdefrksmp", "khmsfrdpc", "pdmkrcfs"},
            new List<string> {"hwn", "whn"},
            new List<string> {"rxhbzyedclofgwmuktsp", "xlmozsbgkcfeyurthdw", "psgtkcfazdwomblhyerxu", "ytvfsxukgwmlrzdhobec"},
            new List<string> {"nrvyx", "vytxn", "xyvn", "nxvy", "xnyv"},
            new List<string> {"qct", "cqt", "tcq"},
            new List<string> {"y", "dy", "lcwtunshbmy", "fy", "ry"},
            new List<string> {"cnboedgyxatrk", "ktdbeocgnay", "wbkgtecnyahmodq", "nxbtgzcsyeukrado", "ydagcekbfont"},
            new List<string> {"jytulh", "yhtlz", "fwtrkhly", "bylht"},
            new List<string> {"huigqrok", "ikhrong", "bighkwor", "kgxrhosi"},
            new List<string> {"zbkrpelxtsohdaw", "ewzkvcxrdtboas", "rabkdwoxyneszt", "axhkbzrwdteos", "rtbowkelsxzad"},
            new List<string> {"aonplewqryh", "euyqrfncsovkld", "byalnwiezroq", "enobxrlqy", "pmgzeryonql"},
            new List<string> {"akxpsmecuj", "kfgsexjm", "oxqfeskjm", "yervixmdktlshbj"},
            new List<string> {"r", "r", "r", "r", "r"},
            new List<string> {"rdghefnubpzkma", "dhubafromtpekzgn", "knmhfjduebpgraz", "zpekdbfamrnihug"},
            new List<string> {"ybcgsmlwhovidfezp", "omfpzqugycwrhbs"},
            new List<string> {"x", "x"},
            new List<string> {"vjahspyncxzmie", "zmpu", "krpmzog", "tfpmkz"},
            new List<string> {"morafxw", "xyckafoqwjm", "ialpowmf", "xhrsmwokbfjazu", "anmfowdbq"},
            new List<string> {"gdpblscxazjrmikoyth", "exrolqfahdbymcwpksjt", "gtmadncysrlhpojvxkib"},
            new List<string> {"nxdilkwregfbaoqp", "exnjrbsifwypkqovag", "fgrotinqbwpkxae", "flndzeoxkwgrcptibqa"},
            new List<string> {"sidjln", "mjslodni", "ztdoxjnise", "odnsehfjti", "dnsyij"},
            new List<string> {"qx", "wmxtj", "wxzmtucqy", "godkvenhxpb", "xrztj"},
            new List<string> {"xofhvkjytqus", "ytdqjkufimvx", "uwyqntcvfpxkj"},
            new List<string> {"rdtqukinob", "wzufpcolmskynvteh"},
            new List<string> {"vnab", "kouvrfe", "ljvcd", "wqbdpvsy", "bighvnmx"},
            new List<string> {"frgsavwjel", "fjlrwsaveg", "afeljgrwsv", "jlvsrewafg", "kvfesjlwgra"},
            new List<string> {"ygdszflehmwcnbopiatxju", "jdnupgzmilsywaechoft"},
            new List<string> {"da", "rzfvailh", "bhorq", "ctgujpmsw"},
            new List<string> {"ymbnzldsi", "ltvsfm", "mgcsl", "emslgw"},
            new List<string> {"taqecxvdypifblzgk", "cekxfvgplrnqbty", "vejogtfwqbyknlrpxc"},
            new List<string> {"souwzdkcbqf", "awzqgvbscukdpxn", "bcszjdfkuimwq", "sdbcuzqkw"},
            new List<string> {"avrlf", "kerlgmuahvc", "wavfibznrol"},
            new List<string> {"upnkam", "xmjt", "milex"},
            new List<string> {"rxotufwczkpvia", "pajkvhwtme", "gpnektwljasv", "pknaqwtvey", "wpadktnlvjb"},
            new List<string> {"kpfj", "syurwad", "asyvld"},
            new List<string> {"p", "bpz", "po"},
            new List<string> {"s", "u", "s"},
            new List<string> {"ksvbeno", "uyfivq", "kbjodvh", "czptrmawg"},
            new List<string> {"xtiqze", "xtisdz"},
            new List<string> {"pylbdvkncjurmgh", "yhbdoltvrpiknmjucg", "vbmlhynrcugjpdk"},
            new List<string> {"byoavnixtlzepjds", "sapxunqeizdvblyho", "qvlmeoisanzyhdxpb"},
            new List<string> {"ifykcw", "iyckw"},
            new List<string> {"u", "p", "s", "s"},
            new List<string> {"f", "f", "f", "f"},
            new List<string> {"fvbjxaiklos", "ufqnvcgxikdpalobt", "bixlarfkvo"},
            new List<string> {"ygpsxce", "cpdsfygaxueb", "ycgsxep", "epcxsgty", "pctxesgy"},
            new List<string> {"meawzoqnidgh", "hodmagqnzew", "mwhzndaqgjoe", "cdhseoqauwngzmx", "oawmeqfdnhzg"},
            new List<string> {"yrlvejxocsh", "hvjrsmloyne", "nsrvyojlhe"},
            new List<string> {"zhufxvrkcdmwqlsa", "lergvwdqnaosxtzchukbj"},
            new List<string> {"xbvyt", "ybvndgxt", "gzxtonyb", "xbcuwtyp"},
            new List<string> {"creoxajkgvq", "vgljkrexacwmhq"},
            new List<string> {"wckjovuftgmb", "boktfjuvgmwc"},
            new List<string> {"cguaojyvre", "ohiknuqags", "lcazjyguor"},
            new List<string> {"inhyfk", "kify"},
            new List<string> {"uhtqci", "tfoqacim", "srvcjytkqgx", "hqctz", "qmctahizn"},
            new List<string> {"vekplqxuhrm", "kmeuprlvqxh", "vhlrkmpxuqe"},
            new List<string> {"at", "tagexyi", "mpt", "yxta"},
            new List<string> {"uezmyjqvbgspirlc", "fydbljgwmzxquecop", "zptrgeybcqmluj", "pelzjcugymtbvq"},
            new List<string> {"fakguojpbsic", "ubcfgyjakpiso", "bliusctfvkampjog", "fybsicjawkupog"},
            new List<string> {"kmxerqlautij", "zxidayte"},
            new List<string> {"imbngcehtvs", "oipfmkrqusnwxdzyl", "imasjvn"},
            new List<string> {"pek", "e", "ei", "ep", "ex"},
            new List<string> {"yuw", "uyw", "wdysu"},
            new List<string> {"omikta", "zjvatmw", "txsma", "cm", "lndgqmry"},
            new List<string> {"cwazbkolvys", "liyoveacbswj", "siwokbavleyc", "rocsyndufablvwx", "aylbvcojesw"},
            new List<string> {"nazfjsrouhgtv", "zgsprothnufav"},
            new List<string> {"ptmshxwqk", "sebqodwi", "euqsw", "zwousq"},
            new List<string> {"uqltjsikhpvefdawycbzg", "plyhvtieubakzswqcfjgd", "wehjvikyfpcsgaqtlbuzd", "sfibzvquyljekgthpwcda", "cgbtvdolizaeqypfksxjuhw"},
            new List<string> {"izeqstg", "sgiqzet"},
            new List<string> {"fqbmpoxscydhrtljzga", "cfqodxevmajhbrplzt", "oecfrzvbpdaqhtjlxm", "adfbxrmqlctzpjho"},
            new List<string> {"dsmewbhpvrfuknj", "opcvhwtrqkue", "rwvkguhpzoe", "vxpghreuiwqk"},
            new List<string> {"fjzi", "ftmizn"},
            new List<string> {"xumjz", "ujxymg", "zumjx", "ujmx"},
            new List<string> {"n", "l", "l", "x"},
            new List<string> {"ghwfslriojz", "rfzliwoe", "flrziobw", "ifcpozlrw"},
            new List<string> {"smvfnglxaeczqwukojhbi", "uieagsoqbhvlmjcfxwknz", "nxoacfwemhijsgqvzbkul", "qanmsiwvflcjbxzoeugkh"},
            new List<string> {"pzciwneljbghoufdvymtqar", "exlhrjvkpnmdoqbtzusiwcgf"},
            new List<string> {"uxjwpobgcflndqairke", "oktwumrzjlyedagxbinsfp"},
            new List<string> {"oibhmyeguqkxjrcpawzfvds", "vhsauyxdrobwcjmkzqepgif", "gxhiwozfkbsecamrypudvjq", "mxywofehvsczapkbuidqjgr", "xsmvybwqdgrzeucfahpojik"},
            new List<string> {"gdtlkuomn", "ytkueoglh"},
            new List<string> {"xgimja", "gjxibma", "mjbagix", "xaiojmg", "mgjaxi"},
            new List<string> {"sgnfdiz", "dto"},
            new List<string> {"yhkvqrzw", "hyknjrzvq", "xtrhdsvkzoqy", "ykqvzhr", "zkqyhanegrv"},
            new List<string> {"tzqrhavysuodmjp", "abvpofyzhmrjqdt", "yzopriuqnvmtahjd", "atmryjpzhovqgd"},
            new List<string> {"cyljrwofasq", "afoqswrjclu", "carljswfkoq", "ljwsfocqyra", "xjolqcwfars"},
            new List<string> {"r", "o", "ak", "xdje"},
            new List<string> {"lfyjxpoeau", "yhlgcftszpr", "pkylfomw"},
            new List<string> {"lunijqekwg", "vafgdsjqeklniw", "yeglwqkjin", "leqgjkniyw"},
            new List<string> {"mpvlijnfbz", "jzmfbplnvih", "jqdlpvbmnzif"},
            new List<string> {"tk", "tk", "qkst", "kt", "tk"},
            new List<string> {"mdowpcnxgbvuytqezljsk", "tbnzcduipewvxlkqrsmjyga"},
            new List<string> {"ilumzjpqotcv", "fgtmowyx", "gdsotkrm"},
            new List<string> {"yncslevbgrqmizwu", "brclynqgzvuewisfm", "lgbzcesuvqnrwmyi"},
            new List<string> {"bjmzopcdiqlyueh", "olyupebiqcmzjhd"},
            new List<string> {"eubsjrvwmyinzkaqdgcf", "icqzjksbyregauvfdwnm", "jugdnbsczwqfarvkyiem", "benyrimfwzaqvukdscjg", "ndcuvaziekbwyjrqgsfm"},
            new List<string> {"g", "c", "c"},
            new List<string> {"gvyfqupnxtswb", "uvtykbjxgifcqz", "lhvobuxgqfetmy"},
            new List<string> {"dpzgaulb", "plqugbrdmac"},
            new List<string> {"htr", "kgrt", "rt", "tr", "trg"},
            new List<string> {"o", "qv", "lr", "m", "l"},
            new List<string> {"qotxnerijpfbkcagylh", "nilhcfrpkjgboxaqey", "ognqxipefrbjhlkacy", "kojtilqxyrhbpancgfe", "qjilgekcfsnhxapomrby"},
            new List<string> {"fes", "feoijn", "ef", "ef", "ef"},
            new List<string> {"dlzga", "tlsidg", "gdl", "lpdgh"},
            new List<string> {"onysxwkqlcgdemhup", "mzlscwgkdnouexyp", "kzdubeoyslgnpcxm", "dymulpowksnegxc", "kpusvxldgyaonemrci"},
            new List<string> {"xh", "e"},
            new List<string> {"utbirhymae", "yzehmoukq"},
            new List<string> {"ijvulcmbrgkyxao", "uvrajglcbomkxiy"},
            new List<string> {"xo", "zo", "o", "xo", "o"},
            new List<string> {"mbghatcenlifqjdkp", "ejscikpgvtomhnxqzf"},
            new List<string> {"stpvo", "cjvpthsl", "spvdnyrt", "qvypftsx"},
            new List<string> {"obrxaqyudvinmk", "qlimnvosubahydgkecrx", "yrftzoxkjqvbaidm", "kvqaxdmboirwy"},
            new List<string> {"dxj", "xdj", "jxd", "jxd", "djx"},
            new List<string> {"hfjeucmkrvnwxs", "nxujekrqmsbofhc"},
            new List<string> {"ezarol", "lebz", "bzel"},
            new List<string> {"jgmzcl", "jlzcmg", "cmlzjg", "jmclzg", "gmcjzl"},
            new List<string> {"o", "u"},
            new List<string> {"bdfqljiuacptzvgrxoe", "pauvztlihdqrjofgx", "xtrjvzuaipfldgoq", "jzrdtxqlwiavungfpo"},
            new List<string> {"cjurgpeyvlzhafx", "aurhsfbvpeyxgjzc", "gzvhejlkpxyfocura"},
            new List<string> {"rvyfbicazduolwtgqk", "qklnrgyaofdzvciwut"},
            new List<string> {"qsw", "qs"},
            new List<string> {"nrfgxpujobhk", "rxmpnokdgbjfi", "lxbngkrfyjvcoz"},
            new List<string> {"e", "e", "zegkx", "e", "e"},
            new List<string> {"kon", "k", "k"},
            new List<string> {"ekvi", "iekv", "ekvi", "ivek"},
            new List<string> {"jfbyxwhrne", "nxjhrfbdwy", "bewhryfjtnx", "mfhoxyjbrsnw"},
            new List<string> {"bn", "n", "sxv", "d"},
            new List<string> {"egrzknhbxfvqtdcu", "edhrioxvjgnzbf"},
            new List<string> {"yjoskmhw", "kdtqfehazbyu"},
            new List<string> {"zq", "zq", "qz", "uqz"},
            new List<string> {"ilbpcz", "ibcqplz", "gczbpil"},
            new List<string> {"nikychwgab", "caibgwklndy", "ckbenqwuafyg"},
            new List<string> {"qubikjdz", "jkiuzdb"},
            new List<string> {"gwmavrpfsdnkyizuelt", "yuqnvjmlogpizcfetx"},
            new List<string> {"tnsf", "thnfs", "tfsn", "sntf", "nstf"},
            new List<string> {"vflagunhs", "aiwvlhjfsunxg", "ulvhgfsna"},
            new List<string> {"yajtfdwh", "hzdpalftjb"},
            new List<string> {"nazpqismug", "pznuismgq", "mgiqnupwsz", "mgptzusniq", "boifzpmsuqgn"},
            new List<string> {"ohu", "ht", "hpygo", "ijkdfhcb", "uhno"},
            new List<string> {"kfzmrhyjvw", "hzgxpjbkwvyr", "zykmfrvwshj"},
            new List<string> {"yqsezgcojbw", "zjsgcoeqby", "jgfsbozqyec", "czsgoyfbjqe"},
            new List<string> {"fjywktd", "yjktfwd"},
            new List<string> {"nwvrodtpqy", "xtrvnosihzgq"},
            new List<string> {"gdwcmlxiqtynsjozapeur", "xwlgsjatqzycnodprmue", "adxtgqujrcopnlwsmezy"},
            new List<string> {"snep", "shwz"},
            new List<string> {"unvpgc", "guncvp"},
            new List<string> {"suctpbxogra", "kcxvgteayu", "ztgxuacy"},
            new List<string> {"pewbhlvjtg", "omskldnz", "iafryucxq"},
            new List<string> {"zoucjefxpdta", "xbfijrelpucsot", "ktoexjpcauf", "jtezoxkpfhcduw"},
            new List<string> {"xiaszncr", "asxnircz", "xzncrsai", "rixseuzanc", "nzaicrsx"},
            new List<string> {"owtvxqcizrapl", "alqxivcprzowt"},
            new List<string> {"ltrhdykufvwex", "ekxvfldwuhrt", "ervktduwlhfjax"},
            new List<string> {"ylvgpjthiex", "snmbgjfzduxqearikc"},
            new List<string> {"eml", "bkhyl", "rzsoitwqn", "dacupjev", "fldc"},
            new List<string> {"uqigoj", "ojui"},
            new List<string> {"zgbsumeycaxvontwdkij", "jbtelqcxnumsoakiwyvg", "waseyvijugnkobptcmx", "atesbkmjuhcvfngxywoi"},
            new List<string> {"pc", "pc", "ikyp"},
            new List<string> {"xtgvlenosarwubmfihz", "txganvweourhbqslfmiz", "lientrsuwghobfmvxaz", "taluorneizhswmbxgvf", "zginuholscexmftrbwva"},
            new List<string> {"xjkv", "xtouw", "tywx", "oxwt"},
            new List<string> {"zk", "cz", "bz"},
            new List<string> {"qcp", "qpc"},
            new List<string> {"ogptyeunzsqmarjc", "jrvlopzynes", "xoszpnjryle", "zbrnypsoej"},
            new List<string> {"nuigyflbxs", "yxunspgj", "vnuscztymqowgxr", "ixnyshgu"},
            new List<string> {"pdn", "cyskxdp"},
            new List<string> {"ewlkgbdxqtiz", "eqgxitldbzkw", "kbdexzgitwql"},
            new List<string> {"c", "p", "t", "v", "gqh"},
            new List<string> {"uvigbjqk", "ibvugq", "vbuiqg"},
            new List<string> {"wzdca", "dzawc", "cawzyd"},
            new List<string> {"mfaigwlu", "pygxjmufwal", "ugfwlam", "glmafuw"},
            new List<string> {"bewfkxsvl", "yxdqnmaturov"},
            new List<string> {"fdrbt", "mxjnfdqpc", "wdltfo", "adwletfr"},
            new List<string> {"t", "pgo", "e", "tiabc"},
            new List<string> {"zbthk", "zbkhatr", "zbhtk"},
            new List<string> {"flxwhbzkei", "lwkhxfezbi", "xelfwbzhik", "bhzefxkliw", "klizhwbfxe"},
            new List<string> {"btmwkoqs", "bstomkqw", "wskomtbqi", "kswtbmqo", "kqbswotm"},
            new List<string> {"kdfbzj", "bfdzjm"},
            new List<string> {"bf", "ef", "f", "fut", "bf"},
            new List<string> {"bvl", "lvu"},
            new List<string> {"kezwynmfrgahlbqsjtdxiovpu", "wmaukoqsldvheztxrgjpifbny", "qgkrwvaiznhpmtlxjubesdoyf", "osverdamnxjufcybpkztqighwl"},
            new List<string> {"nza", "anz"},
            new List<string> {"wfjsdaq", "iwlrou", "ykwftq"},
            new List<string> {"zgtuvqxmljwyaifcbp", "pcgytlqjvbaxwzimf", "cmqzwaljvbufyigptx", "sxgvcbweymiflqajtkpz", "fhgmjpwclzibtvaqxy"},
            new List<string> {"rohqjmnvlsdaigywbxe", "xmhiarjdogqwbvnlsey"},
            new List<string> {"jhz", "jhz", "jzh"},
            new List<string> {"oemyvhgznpblsq", "hpsvzycebqlmng", "elhnwqdpbsgzyvm", "cenomgyzhqlsbvp"},
            new List<string> {"gdnc", "wncd"},
            new List<string> {"tnlprwbcsaygzqxuoev", "rxqdasecgwbzmfvntpl"},
            new List<string> {"jtucglizkohrafs", "ebjhogu", "hdugoj"},
            new List<string> {"ncyvqk", "oulfaxqnerid", "ptmsynbvkwq"},
            new List<string> {"mxihwyzetlbnkpfs", "ksqwhxtzbenfpim", "nqbtxwsepfmkih", "khixywsmbnetpfl", "peikctmafswhnbx"},
            new List<string> {"phylqxrdtg", "yxtapqni", "nkiwytuveqxp"},
            new List<string> {"lhqrfys", "sqdfly", "ysfhlq", "sylfq"},
            new List<string> {"sqpjuobilhmtvrxaz", "kuwgncfdv"},
            new List<string> {"dqzke", "qezkd", "kqezd", "zkqed", "kdqez"},
            new List<string> {"lio", "iol", "loi", "lio", "oil"},
            new List<string> {"hvpwi", "rhvp", "fpysmvd", "tpvrl", "vph"},
            new List<string> {"idjeoxvyqaufgpnlc", "xnplcqjvdyigsaef"},
            new List<string> {"y", "qw"},
            new List<string> {"rhb", "fpqsiadrjkl"},
            new List<string> {"hinvdck", "kvcahnid", "fhcupntkvdqijmy", "dvnchik", "aivcnhxkd"},
            new List<string> {"xqugmnktofslbpevzd", "yaqztjnicrwd"},
            new List<string> {"biadvoeznswx", "iaxszcdwboj", "isbdkxzwoanve", "gikqxzorsadfwb", "asozrwidqxvb"},
            new List<string> {"bvotgwrxe", "xbhryeov", "ojrvxebi", "vxeorb"},
            new List<string> {"fb", "rqwl", "qlrjyfp", "nkhgmov"},
            new List<string> {"zexjvfbwro", "wzvxorfjbe", "vorwzexbjtf", "xeovwfjbzr"},
            new List<string> {"owfmx", "uxomf", "mfo", "cfkmo"},
            new List<string> {"atwsbvcn", "mijkzngueoy"},
            new List<string> {"twqprciyaxkb", "barckwiptqyx", "iabyqwtcrkxp", "rqbkipctxywa"},
            new List<string> {"vmhzjek", "tx", "aix", "dsa"},
            new List<string> {"byzxqpgureth", "gbxryhptqiezuc", "lqrzjwythegxubp", "hqruytzegbxp", "tepughsrqzybx"},
            new List<string> {"hwydxbeflai", "yhewcfbaixd", "yhwadxfeib"},
            new List<string> {"hi", "h", "h", "h"},
            new List<string> {"mhket", "mtkh"},
            new List<string> {"loacixzmfy", "fmxlzaoyci", "ylifaxopczm", "czyafoxmli"},
            new List<string> {"ymrfxiwbse", "ihpqjuaczd"},
            new List<string> {"ealixkwz", "gocmqyfthp"},
            new List<string> {"gedjwnt", "wtdezgn", "hgcuwrtnped", "zjngtdlexw"},
            new List<string> {"jk", "jk", "kj", "jk", "jk"},
            new List<string> {"gkxldasfhqncbiyu", "hnpfbycsgqkuldex", "hquxfksigydlcnab", "cxauqgdiyfbnkshl"},
            new List<string> {"niahryvlxbekt", "dyhknvbaleirtx", "tknljyvrihbzxe", "seyxknvihrcbtl", "bxrhukldytvneiw"},
            new List<string> {"vuq", "cfawvlt", "rhnvzu"},
            new List<string> {"wxlhvnmispbot", "whvbcxmolntips", "snhtmbpwifulxov", "itswhupmncvolbx", "rhtlsdpiwonbkqvxm"},
            new List<string> {"ojmyc", "kfzuehvirps"},
            new List<string> {"mk", "km", "km"},
            new List<string> {"fjyx", "jitrevpfy", "yjs", "jyxmiect", "dykgjnzbl"},
            new List<string> {"rbwpjflnoegkqt", "hwxceyimsdzntvu"},
            new List<string> {"golf", "fzgol", "dlxfomg", "lfozg", "floag"},
            new List<string> {"dfbmcyi", "yvzpkrbc", "icybu"},
            new List<string> {"mcbditlrfgeaoh", "camdhrfbvoglei", "riagefbmclvokqz", "dbfogjmeacrpl", "lwuogecanfxsbrmy"},
            new List<string> {"lgsnwuockhmpxibedqzaf", "cvmiepdsubkgwzhf", "bsvipdjwcfkmezugh", "wgfzicsmubpdkeh"},
            new List<string> {"iyeorgvpmutnhqcwxj", "jqoguadpnmrk", "nmpquzglaorsj"},
            new List<string> {"apjqhruongvztmiywecl", "padwbieyshonfrtxqcukzglv", "yolrhezqicgpmvtaunw", "mljzahrwcpqygvonuite"},
            new List<string> {"szhjetf", "sdtozreuhmfp"},
            new List<string> {"f", "f", "mf", "f"},
            new List<string> {"gnjqcad", "idlhjay", "rejbwamoud", "danxj", "zjkdia"},
            new List<string> {"lupiwyqntjgekvsr", "gwqupjykitrlnsbo"},
            new List<string> {"ojcxmuqsrhyv", "lgcovdyhnifsp"},
            new List<string> {"wphvcu", "lznsm"},
            new List<string> {"wpq", "qpw", "wqp", "pwq", "fqwhp"},
            new List<string> {"nyzx", "ubpx", "xwi", "wtxhe"},
            new List<string> {"vkujyxtido", "tvouidyjxk", "vidkjuoxty", "uxtoivdkjy", "yvukijdoxt"},
            new List<string> {"fpuboyiwdktvc", "hsqnzuagr"},
            new List<string> {"swabt", "mwsb", "sbwm", "bws"},
            new List<string> {"idlshcnf", "ficnd", "tdfcin", "nicdf"},
            new List<string> {"ajodwgmsy", "wmjvoygd", "ojdwmyg", "dovgwjmy"},
            new List<string> {"yemtzisjpxchanuovwdkr", "evxtomkyhrupwsnizac", "ytevcsimkwrnzoauhpx"},
            new List<string> {"whley", "dhyetlqf"},
            new List<string> {"fqx", "xf", "bfxz"},
            new List<string> {"ipwvb", "vdnb", "rcvnf", "chvr", "xjtvyez"},
            new List<string> {"sdpuoewx", "wfqrphkdelosbvgyum", "pudzioesnw", "idatsupewo"},
            new List<string> {"knfheau", "kanehuf", "unekfa", "klcsnemaufy"},
            new List<string> {"yhuvigcrp", "rivgypcuh", "urphgvciy", "iyhrcvupg", "vuphryicg"},
            new List<string> {"flozkyvhnwxr", "fvpsybhlwrz", "hzqvmfgrl", "irholckaveszf"},
            new List<string> {"gypwufz", "agspwqmuyz", "yogwpzu"},
            new List<string> {"c", "oc"}
        }; 
    }
}