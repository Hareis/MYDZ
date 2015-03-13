/// <summary>
/// 字符串验证类
/// </summary>

//去掉左右空格
String.prototype.Trim = function(g) { 
    var value = this.replace(/(^\s*)|(\s*$)/g, ""); 
    if(g == "g"){
        value = value.replace(/\s/g,"");
    }
    return value;
}  

//去掉左空格
String.prototype.LTrim = function() { 
    return this.replace(/(^\s*)/g, ""); 
}  

//去掉右空格
String.prototype.RTrim = function() { 
    return this.replace(/(\s*$)/g, "");
}

//验证是否为空
String.prototype.IsEmpty = function () {
    return this.Trim() == "";
}

//判断邮箱
String.prototype.CheckEmail = function()
{   
    var MyNumber =  this.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/);
    if(MyNumber == -1)
        return false;
    return true;
}

//判断整数
String.prototype.CheckNumber = function() {
    var MyNumber = this.search(/^-?\d+$/);
    if(MyNumber == -1)
        return false;
    return true;
}

//判断正整数
String.prototype.CheckInteger = function () {
    var MyNumber = this.search(/^\d+$/);
    if (MyNumber == -1)
        return false;
    return true;
}
//判断价格
String.prototype.CheckPrice = function()
{   
    var MyNumber =  this.search(/^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/);
    if(MyNumber == -1)
        return false;
    return true;
}

//判断折扣
String.prototype.CheckDiscount = function()
{   
    var MyNumber =  this.search(/^[-]{0,1}\d{1,10}$|^[-]{0,1}\d{1,10}\.\d{1,2}\w?$/);
    if(MyNumber == -1)
        return false;
    return true;
}
//判断是否包含特殊符号
String.prototype.Symbols = function () {
    var txt = new RegExp("[ ,\\`,\\~,\\!,\\——,\\（,\\）,\\【,\\】,\\，,\\；,\\？,\\、,\\。,\\《,\\》,\\@,\#,\\$,\\%,\\^,\\+,\\*,\\&,\\\\,\\/,\\?,\\|,\\:,\\.,\\<,\\>,\\{,\\},\\(,\\),\\',\\;,\\=,\"]");
    return txt.test(this);
}
//判断日期和时间
String.prototype.CheckDateTime = function () {
    var MyNumber = this.search(/^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/);
    if(MyNumber == -1)
        return false;
    return true;
}
//判断时间
String.prototype.CheckTime = function()
{
    var MyNumber = this.search(/^(\d{1,2}:\d{1,2})$/);
    
    if(MyNumber == -1)
    {
        return false;
    }
    else
    {
        var TimeSpan = this.split(':');
        
        if(parseInt(TimeSpan[0]) >= 1 && parseInt(TimeSpan[0]) <= 24) 
        {
            if(parseInt(TimeSpan[1]) >= 0 && parseInt(TimeSpan[1]) <=60 )   
            {
                return true;
            }   
        }
        
        return false;
    }
}

//判断生日
String.prototype.CheckDate = function()
{
    var MyNumber =  this.search(/^\d{4}-\d{1,2}-\d{1,2}$/);
    
    if(MyNumber == -1)
        return false;
        
    var y = parseInt(this.split("-")[0], 10);
    var m = parseInt(this.split("-")[1], 10);
    var d = parseInt(this.split("-")[2], 10);
    
    switch(m)
    {
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
            
            if(d>31)
                return false;
            return true;
            break;
        case 2:
            if((y%4==0 && d>29) || ((y%4!=0 && d>28)))
                return false;
            return true;
            break;
        case 4:
        case 6:
        case 9:
        case 11:
            if(d>30)
                return false;
            return true;
            break;
        default:
            return false;
            break;
    }
}
//比较当前日期
String.prototype.CompareDate = function()
{
    var OneMonth = this.substring(5,this.lastIndexOf ("-"));

    var OneDay = this.substring(this.length,this.lastIndexOf ("-")+1);

    var OneYear = this.substring(0,this.indexOf ("-"));
      
    if (Date.parse(OneMonth+"/"+OneDay+"/"+OneYear+" 23:59:59") >= Date.parse(Date()))  
    {   
        return true;   
    }   
    else  
    {   
        return false;   
    }   
}
//判断电话号码
String.prototype.CheckPhone = function()
{
    var MyNumber =  this.search(/^(\d{3,4}-)?\d{7,8}(-\d{3,4})?$/);
    if(MyNumber == -1)
        return false;
    return true;
}

//判断手机号码
String.prototype.CheckMoblieNo = function()
{
    var MyNumber = this.search(/((^[1])(3[0-9]\d{8}|4[0-9]\d{8}|5[0-9]\d{8}|6[0-9]\d{8}|8[0-9]\d{8})$)/);
    if(MyNumber == -1)
        return false;
    return true;  
}
//判断IP
String.prototype.CheckIP = function()
{
    var MyNumber = this.search(/^([1-9]|[1-9]\d|1\d{2}|2[0-1]\d|22[0-3])(\.(\d|[1-9]\d|1\d{2}|2[0-4]\d|25[0-5])){3}$/);
    if(MyNumber == -1)
        return false;
    return true;  
}
//判断Mac
String.prototype.CheckMac = function()
{
    var MyNumber = this.search(/[A-F\d]{2}-[A-F\d]{2}-[A-F\d]{2}-[A-F\d]{2}-[A-F\d]{2}-[A-F\d]{2}|[a-f\d]{2}-[a-f\d]{2}-[a-f\d]{2}-[a-f\d]{2}-[a-f\d]{2}-[a-f\d]{2}/);
    if(MyNumber == -1)
        return false;
    return true;  
}
//判断邮政编号
String.prototype.CheckPostCode = function()
{
    var MyNumber =  this.search(/^[0-9]{1}[0-9]{5}$/);
    if(MyNumber == -1)
        return false;
    return true;
}
//获取小数位数
String.prototype.DecimalLength = function () {
    return this.replace(/(\d*\.?)/, "").length;
}
//判断字符的长度
String.prototype.GetStringLength = function()
{
    var MyLength = this.length;
    var Str = this;  
    var TestStr=''; 
    var TheLen=0;
    for(var i=0;i<MyLength;i++)   
    { 
        TestStr = Str.charCodeAt(i);
        if(TestStr>255)
        {
            TheLen = TheLen + 2; 
        }
        else
        { 
            TheLen = TheLen + 1;   
        }
    } 
    return TheLen;
}
//获取字符串强度
String.prototype.GetPswStrength = function () {
    var Json = {};

    var char = '';
    var TheLen = 0;
    var China = [], Num = [], Capital = [], Lower = [], Character = [];
    for (var i = 0; i < this.length; i++) {
        char = this.charCodeAt(i);
        if (char > 255) { //中文
            China.push(char)
            TheLen = TheLen + 2;
        } else {
            if (char >= 48 && char <= 57) { //数字  
                Num.push(char)
            } else {
                if (char >= 65 && char <= 90) {//大写  
                    Capital.push(char)
                }
                else {
                    if (char >= 97 && char <= 122) {//小写  
                        Lower.push(char)
                    }
                    else {//符号及其他
                        Character.push(char);
                    }
                }
            }
            TheLen = TheLen + 1;
        }
    }

    var ModeLength = (China.length > 0 ? 1 : 0) + (Num.length > 0 ? 1 : 0) + (Capital.length > 0 ? 1 : 0) + (Lower.length > 0 ? 1 : 0) + (Character.length > 0 ? 1 : 0);

    Json = {
        Length: TheLen,
        China: China,
        Num: Num,
        Capital: Capital,
        Lower: Lower,
        Character: Character,
        ModeLength: ModeLength
    };

    return Json;
}
//清除Html标签
String.prototype.ClearHtml = function () {
    return this.replace(/<[^>]+>/g, "").replace(/</g, "").replace(/>/g, "").replace(/\//g, "").replace(/\\/g, "");
}

//格式化日期类型
Date.prototype.FormatString = function(fmt) {     
 var o = {     
 "M+" : this.getMonth()+1, //月份     
 "d+" : this.getDate(), //日     
 "h+" : this.getHours()%12 == 0 ? 12 : this.getHours()%12, //小时     
 "H+" : this.getHours(), //小时     
 "m+" : this.getMinutes(), //分     
 "s+" : this.getSeconds(), //秒     
 "q+" : Math.floor((this.getMonth()+3)/3), //季度     
 "S" : this.getMilliseconds() //毫秒     
 };     
 var week = {     
 "0" : "\u65e5",     
 "1" : "\u4e00",     
 "2" : "\u4e8c",     
 "3" : "\u4e09",     
 "4" : "\u56db",     
 "5" : "\u4e94",     
 "6" : "\u516d"    
 };     
 if(/(y+)/.test(fmt)){     
     fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));     
 }     
 if(/(E+)/.test(fmt)){     
     fmt=fmt.replace(RegExp.$1, ((RegExp.$1.length>1) ? (RegExp.$1.length>2 ? "\u661f\u671f" : "\u5468") : "")+week[this.getDay()+""]);     
 }     
 for(var k in o){     
     if(new RegExp("("+ k +")").test(fmt)){     
         fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));     
     }     
 }     
 return fmt;     
} 

//删除数组元素
Array.prototype.del = function(index) {
    if(index < 0) {
        return this;
    } else {
        return this.slice(0, index).concat(this.slice(index + 1, this.length));
    }
}

//删除数组元素
Array.prototype.remove = function (from, to) {
    var rest = this.slice((to || from) + 1 || this.length);
    this.length = from < 0 ? this.length + from : from;
    return this.push.apply(this, rest);
};

//获取包含标签的html代码
jQuery.fn.outer = function () {
    if ($(this).length > 0) {
        return $($("<div></div>").html($(this).clone(true))).html();
    }
    else {
        return "";
    }
}

//将字符串转换成Json格式
String.prototype.ToJson = function () {
    return (new Function("return " + this))();
}

//将字符串转换成银行卡号显示格式
String.prototype.ToBankCardNumber = function () {
    return this.replace(/\s/g, '').replace(/(\d{4})(?=\d)/g, "$1  ");
}
//尾字母匹配
String.prototype.EndWith = function (s) {
    if (s == null || s == "" || this.length == 0 || s.length > this.length)
        return false;
    if (this.substring(this.length - s.length) == s)
        return true;
    else
        return false;
    return true;
}
//首字母匹配
String.prototype.StartWith = function (s) {
    if (s == null || s == "" || this.length == 0 || s.length > this.length)
        return false;
    if (this.substr(0, s.length) == s)
        return true;
    else
        return false;
    return true;
}
///选中文本
$.fn.setSelection = function (selectionStart, selectionEnd) {
    if (this.lengh == 0) return this;
    input = this[0];

    if (input.createTextRange) {
        var range = input.createTextRange();
        range.collapse(true);
        range.moveEnd('character', selectionEnd);
        range.moveStart('character', selectionStart);
        range.select();
    } else if (input.setSelectionRange) {
        input.setSelectionRange(selectionStart, selectionEnd); 
        input.focus();
    }
    return this;
}
///选中所有文本
$.fn.focusEnd = function () {
    this.setCursorPosition(this.val().length);
}
$.fn.setCursorPosition = function (position) {
    if (this.lengh == 0) return this;
    return $(this).setSelection(0, position);
}
