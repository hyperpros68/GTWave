using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu
{
    public  partial class HMTransForm : Form
    {
        TransInfo tInfo = null;
        Tuple curTuple = null;

        public string src_image_file;
        public string trans_image_file;
        public string info_txt_file;

        public string work_path;
        public string work_name;

        public class   Tuple
        {
            public  List<Point> position    = new List<Point>();
            public  int         img_idx     = 0;
            public  string      str_pos     = "";
            public  string      language    = "";
            public  string      src_text    = "";
            public  string      trans_text  = "";
            public  string      trans_img   = "";
            public  string      text_color  = "";
            public  int         text_size   = 0;

            public  static  Tuple   parse(JObject obj)
            {
                Tuple   tuple   = new Tuple();
                tuple.str_pos   = obj["position"].ToString();
                JArray  jPoints = JArray.Parse(tuple.str_pos);
                foreach (JObject point in jPoints) {
                    Point p = new Point(point["x"].ToObject<int>(), point["y"].ToObject<int>());
                    tuple.position.Add(p);
                }

                tuple.img_idx       = obj["img_idx"].ToObject<int>();
                tuple.language      = obj["language"].ToString();
                tuple.src_text      = obj["src_text"].ToString();
                tuple.trans_text    = obj["trans_text"].ToString();
                tuple.trans_img     = obj["trans_img"].ToString();
                tuple.text_color    = obj["text_color"].ToString();
                tuple.text_size     = obj["text_size"].ToObject<int>();

                return tuple;
            }

            public  JObject     ToJson()
            {
                JObject obj     = new JObject();
                JArray  jPoints = new JArray();
                foreach (Point point in position) {
                    JObject jPos = new JObject();
                    jPos["x"] = point.X;
                    jPos["y"] = point.Y;
                    jPoints.Add(jPos);
                }
                obj["position"]     = jPoints;

                obj["img_idx"]      = img_idx;
                obj["language"]     = language;
                obj["src_text"]     = src_text;
                obj["trans_text"]   = trans_text;
                obj["trans_img"]    = trans_img;
                obj["text_color"]   = text_color;
                obj["text_size"]    = text_size;

                return obj;
            }

            public  ListViewItem    getItem()
            {
                ListViewItem item = new ListViewItem(img_idx.ToString(), img_idx);

                item.Tag = this;
                item.SubItems.Add(language);
                item.SubItems.Add(text_color);
                item.SubItems.Add(text_size.ToString());
                item.SubItems.Add(trans_text);
                item.SubItems.Add(src_text);
                item.SubItems.Add(str_pos);

                return item;
            }
        }

        public  class   TransInfo
        {
            public  List<Tuple> tuples      = new List<Tuple>();
            public  string      src_img     = "";
            public  string      trans_img   = "";
            public  string      shape       = "";

            public  static  TransInfo parse(string file)
            {
                TransInfo info = new TransInfo();
                try {
                    JObject tObj = JObject.Parse(File.ReadAllText(file));
                    info.src_img = tObj["src_img"].ToString();
                    info.trans_img = tObj["trans_img"].ToString();
                    info.shape = tObj["shape"].ToString();

                    JArray jTuples = (JArray)tObj["tuples"];
                    foreach (JObject jTuple in jTuples) {
                        Tuple tuple = Tuple.parse(jTuple);
                        info.tuples.Add(tuple);
                    }
                    return info;
                } catch {}
                return  null;
            }

            public  string  ToJsonFile(string file) {
                JObject jObj        = new JObject();
                jObj["src_img"]     = src_img;
                jObj["trans_img"]   = trans_img;
                jObj["shape"]       = shape;

                JArray jTuples = new JArray();
                foreach (Tuple tuple in tuples) {
                    jTuples.Add(tuple.ToJson());
                }
                jObj["tuples"]      = jTuples;

                // write JSON directly to a file
                using (StreamWriter stream = File.CreateText(file))
                using (JsonTextWriter writer = new JsonTextWriter(stream)) {
                    jObj.WriteTo(writer);
                }
                return  file;
            }
        }

        public void DispTuple(Tuple tuple, string work_path)
        {
            pb_tuple_img.Load(Path.Combine(work_path, tuple.trans_img));

            tb_src_text.Text    = tuple.src_text;
            tb_trans_text.Text  = tuple.trans_text;
            tb_text_size.Text   = tuple.text_size.ToString();
            tb_language.Text    = tuple.language;
            pn_text_color.BackColor = ColorTranslator.FromHtml(tuple.text_color);
        }

        public HMTransForm()
        {
            InitializeComponent();
        }

        public  int     init(string src_file, string info_file, string trans_file)
        {
            src_image_file      = src_file;
            trans_image_file    = trans_file;
            info_txt_file       = info_file;

            return 0;
        }

        /*
        public  Bitmap  LoadBitmap(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    var memoryStream = new MemoryStream(br.ReadBytes((int)fs.Length));
                    return new Bitmap(memoryStream);
                }
            }
            else return null;
        }
        */

        private void HMTransForm_Load(object sender, EventArgs e)
        {
            pb_src_image.Load(src_image_file);
            pb_trans_image.Load(trans_image_file);

            work_name   = Path.GetFileNameWithoutExtension(src_image_file);
            work_path   = Path.GetDirectoryName(trans_image_file);

            string  json_file   = Path.Combine(work_path, work_name + "_info.txt");

            Console.WriteLine(work_name);

            tInfo = TransInfo.parse(json_file);
            if (tInfo == null)      return;

            lv_tuple.Items.Clear();
            ImageList sImageList = new ImageList();
            lv_tuple.SmallImageList = sImageList;
            sImageList.ImageSize = new Size(240, 30);

            foreach (Tuple tuple in tInfo.tuples) {
                lv_tuple.Items.Add(tuple.getItem());

                //sImageList.Images.Add(Bitmap.FromFile(Path.Combine(work_path, tuple.trans_img)));
                Bitmap bmp = LoadBitmap(Path.Combine(work_path, tuple.trans_img));
                if (bmp != null) {
                    sImageList.Images.Add(bmp);
                }
            }
            lv_tuple.Items[0].Selected = true;

            Console.WriteLine(work_name);
        }

        private void bt_ok_fix_Click(object sender, EventArgs e)
        {
            if (lv_tuple.SelectedItems.Count > 0) {
                curTuple.src_text   = tb_src_text.Text;
                curTuple.trans_text = tb_trans_text.Text;
                int.TryParse(tb_text_size.Text, out curTuple.text_size);
                curTuple.src_text   = tb_src_text.Text;
                curTuple.language   = tb_language.Text;
                curTuple.text_color = ColorTranslator.ToHtml(pn_text_color.BackColor);

                int s_index = lv_tuple.SelectedItems[0].Index;
                ListViewItem item = curTuple.getItem();
                lv_tuple.Items[s_index] = item;

                lv_tuple.Items[s_index].Selected = true;
            } else {
                MessageBox.Show("리스트를 선택해 주세요");
            }
        }

        private void lv_tuple_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            if (list.SelectedItems.Count == 0)
                return;

            ListViewItem item = list.SelectedItems[0];
            curTuple = (Tuple)(item.Tag);
            DispTuple(curTuple, work_path);
        }

        private void pn_text_color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pn_text_color.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                pn_text_color.BackColor = MyDialog.Color;
        }

        void UploadProgressCallback(object sender, UploadProgressChangedEventArgs e) {
            // Displays the operation identifier, and the transfer progress.
            //Console.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", (string)e.UserState, e.BytesSent, e.TotalBytesToSend, Math.Truncate(((double)e.BytesSent / (double)e.TotalBytesToSend) * 100));

            //progressBar1.Value = int.Parse(Math.Truncate(((double)e.BytesSent / (double)e.TotalBytesToSend) * 100).ToString());
        }

        public  Bitmap  LoadBitmap(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    var memoryStream = new MemoryStream(br.ReadBytes((int)fs.Length));
                    return new Bitmap(memoryStream);
                }
            }
            else return null;
        }


        void ploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            try {
                string Result = Encoding.UTF8.GetString(e.Result);      //파일 업로드 완료후 리턴된 string
                Console.WriteLine("Return Value : " + Result);

                JObject json    = JObject.Parse(Result);
                if (json != null) {
                    string  code = json["code"].ToString();
                    if (code == "0000") {
                        string  conv_file = json["file"].ToString();
                        pb_trans_image.Image = LoadBitmap(conv_file);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Return Execption : " + ex);
            }
        }

        public  void    re_trans(string work_name, string filename) {
            try {
                WebClient myWebClient   = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;
                myWebClient.Encoding    = Encoding.UTF8;
                byte[] fileContents     = File.ReadAllBytes(filename);

                Uri uri = new Uri("http://localhost:9081/re_trans");

                myWebClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
                myWebClient.UploadFileCompleted += new UploadFileCompletedEventHandler(ploadFileCompleted);

                // myWebClient.Credentials = new NetworkCredential("test", "test");  //사용자 인증을 위하여
                //string cc = myWebClient.DownloadString(uri); //사용자 인증체크 위하여 인증 안되면 Exception 발생

                // Console.WriteLine("--- : " + cc);
                myWebClient.QueryString.Add("work_name", work_name);
                myWebClient.QueryString.Add("work_path", work_path);
                //myWebClient.QueryString.Add("firstName", "Hello ssss world");
                myWebClient.UploadFileAsync(uri, "POST", filename);

                Console.WriteLine("File upload started.");
                myWebClient.Dispose();
            }
            catch (WebException ex) {
                Console.WriteLine("\nResponse Exception :\n{0}", ex.ToString());
            }
        }

        private void pool_test(int count, string value) {

        }

        private void    bt_re_trans_Click(object sender, EventArgs e)
        {

            string json_file = Path.Combine(work_path, work_name + "_info_fix.txt");
            tInfo.ToJsonFile(json_file);
            re_trans(work_name, json_file);

            //Close();
        }

        private void pb_trans_image_Click(object sender, EventArgs e)
        {
            ImageViewForm viewForm = new ImageViewForm();
            viewForm.pb_image_view.Image = pb_trans_image.Image;
            viewForm.ShowDialog();
        }
    }
}
