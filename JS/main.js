const examTime = 30;    //考试时间
const topicScore = 5;   //每题的得分
function keyDown(event) {
    if (event.keyCode == 8) {   //退格
        event.keyCode = 0;
        event.returnValue = false;
    }
    if (event.keyCode == 13) {  //回车
        event.keyCode = 0;
        event.returnValue = false;
    }
    if (event.keyCode == 116) { //F5
        event.keyCode = 0;
        event.returnValue = false;
    }
    if (event.ctrlKey && event.keyCode == 82) { //ctrl+r
        event.keyCode = 0;
        event.returnValue = false;
    }
}

function contextMenu(event) {
    // 这个方法不太行有bug
    //event.preventDefault();
    document.oncontextmenu = () => false;
}

function changeCode() {
    /*    onclick = function 不需要加括号
        document.getElementById('ibtn_yzm').onclick = changeCode;*/
    document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
    //这一句使服务器重新生成图片, 问号的作用是忽悠浏览器, 不要让浏览器缓存
}


//默认回车事件是click验证码
function bodyEnter() {
    //document.body.addEventListener("keyup", enterLogin);
    //function enterLogin(event) {
    //    if (event.keyCode == 13) {
    //        document.getElementById("LoginBtn").click();
    //    }
    //}
    $("html,body").on("keyup", function (e) {
        if (e.keyCode == 13) {
            $("#LoginBtn").click();
        }
    });
}

function showTime() {
    var now = new Date();
    years = now.getFullYear();
    maths = now.getMonth() + 1; //return 0-11
    dates = now.getDate();
    hours = now.getHours();
    minutes = now.getMinutes();
    seconds = now.getSeconds();
    hours = (hours < 10) ? "0" + hours : hours;
    minutes = (minutes < 10) ? "0" + minutes : minutes;
    seconds = (seconds < 10) ? "0" + seconds : seconds;
    var titleText = "当前日期时间为:" + years + "年" + "月" + dates + "日" + hours + ":" + minutes + ":" + seconds;
    setTimeout(showTime, 1000); //执行完当前函数后 等待1000ms再执行showtime（）
    document.title = titleText;
}

function countDown() {
    var second = 0;
    var minute = 0;
    idt = setTimeout(ls, 1000);
    function ls() {
        second++;
        if (second == 60) {
            second = 0;
            minute += 1;
        }
        if (minute == 60) {
            minute = 0;
        }
        document.getElementById("TimeLabel").innerHTML = minute + "分" + second + "秒";
        idt = setTimeout(ls, 1000);
        if (minute == examTime) {
            document.getElementById("SubmitBtn").click();
        }
    }
}

function examText() {
    $("#ExamLabel").html("考试时间为" + examTime + "分钟，每小题" + topicScore + "分，考试已用时：");
}

function init() {
    showTime();
    examText();
    countDown();
}

function autoAnswer() {
    let flag = setInterval(() => {
        console.log($(".option").length);
        if ($(".option").length) {
            clearInterval(flag);
        }
        $(".option").each(function (index, element) {
            let i = index + 1
            let str = "#topic" + i + "_0";
            let option = $(element).find(str);
            console.log(option.text());
            option.click();
        })
    }, 500);
}

function banCopy() {
    $(".mask").css("display", "block");
    $(".copy-limit-dialog").css("display", "block");
    return false;
}

function closeBtn() {
    $(".mask").css("display", "none");
    $(".copy-limit-dialog").css("display", "none");
}

function backTop() {
    $(".backtotop").hide();
    $(window).scroll(function () {
        if ($(window).scrollTop() > 100) {
            $(".backtotop").fadeIn();
        } else {
            $(".backtotop").fadeOut();
        }
    });
    $(".backtotop").click(function (e) {
        $("html,body").animate(
            {
                scrollTop: 0,
            },
            500
        );
    });
}