using System.ComponentModel.DataAnnotations;

namespace CoreValidation_2.Models.ViewModels.PureVM.Categories
{
    //PureVM:kullanicinin iletisime gececegi classlar.dogrulama bu classlarda yapilir.3 e ayrılır.
    //1-VM:hem request hem de response ortak kullanilir.
    //2-RequestModel:kullanicinin talep gönderirken yolladigi model.kullanici post request inde model gönderir,
    //ondan istedigimiz bilgileri bu classta property olarak goruruz.VALIDATION BURADA YAPİLİR.
    //3-ResponseModel: Server ın kullaniciya yollayacagi modeldir.
    public class CategoryRequestModel
    {

        //DataAnnotation'da categoryname girilmezse post yapilamaz.
        //DataAnnotation'da yer tutucu operatorleri sayılarla verilir...
        //0, ilgili property neyse direkt o ismi alır...üzerine yazildigi property yi (displaydeki Kategori İsmi
        [Required(ErrorMessage ="{0}  zorunlu bir alandır")]
        [Display(Name ="Kategori ismi")] //Bizim property'mizin kullanıcıya gozukeegi sekil belirtilir.
        [MaxLength(15,ErrorMessage ="{0} en fazla {1} karakter alabilir")]//1, 15 in yerini tutar.
        [MinLength(5,ErrorMessage ="{0} minimum {1} karakter alabilir")]//1, 5 in yerini tutar.
        public string CategoryName { get; set; }//kategori ekleyecegi icin bize name ini yollamali.
        //yukaridakiler sadece üzerine yazilan property(CategoryName) icindir.Diger property icin yeniden yazilir.

        [Required(ErrorMessage ="{0} zorunlu bir alandır")]
        [Display(Name ="Aciklama")]
        [MinLength(10,ErrorMessage ="{0} en az {1} karakter alabilir")]
        public string Description { get; set; }




    }
}
