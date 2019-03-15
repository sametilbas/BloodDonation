var models = [
    {
        name: 'Kan bağışçıları tercihen kan bağışından iki saat öncesine kadar tam bir öğün yemiş olmalıdır.',
        image: '~/Image/DikkatTesvik/bagisoncesi.jpg'

    },
    {
        name: 'Bağışçı, bağış öncesi alkol kullanmamış olmalı ve alkol etkisinde olmamalıdır.',
        image: '~/Image/DikkatTesvik/alcohol.jpg'

    },
    {
        name: 'Son 3 gün öncesinde ilaç kullanılmamalıdır.',
        image: '~/Image/DikkatTesvik/bagısoncesi.jpg'

    },
    {
        name: 'Normal, yağsız besinler alınmış olmalı ve mümkün olduğunca fazla sıvı tüketilmiş olmalıdır.',
        image: '~/Image/DikkatTesvik/bagis.jpg'

    },
    {
        name: 'Bağıştan önceki yarım saat içinde kafein içeren içecekler (kahve, kola vs.) içilmemesi tavsiye edilir.',
        image: '~/Image/DikkatTesvik/bagisoncesi.jpg'

    },


];

var index = 0;
var slaytCount = models.length;
var internal;
var settings = {
    duration: '10000',
    random: false
};
init(settings);
showSlide(index);
document.querySelector('.fa-arrow-circle-left').addEventListener('click', function () {
    index--;
    showSlide(index);
    console.log(index);
});
document.querySelector('.fa-arrow-circle-right').addEventListener('click', function () {
    index++;
    showSlide(index);
    console.log(index);
});

document.querySelectorAll('.arrow').forEach(function (item) {
    item.addEventListener('mouseenter', function () {
        clearInterval(internal);
    })
});

document.querySelectorAll('.allow').forEach(function (item) {
    item.addEventListener('mouseleave', function () {
        init(settings);
    })
});

function init(settings) {
    var prev;
    internal = setInterval(function () {
        if (settings.random) {
            //random index
            do {
                index = Math.floor(Math.random() * slaytCount);
            } while (index == prev)
            prev = index;
        } else {
            //artan index
            if (slaytCount == index + 1) {
                index = -1;
            }
            showSlide(index);
            console.log(index);
            index++;
        }
        console.log(index);
        showSlide(index);
    }, settings.duration)//2sn de bir tekrarlıyacak misal

    clearInterval
}


function showSlide(i) {
    index = i;
    if (i < 0) {
        index = slaytCount - 1;

    }
    if (i >= slaytCount) {
        index = 0;
    }
    document.querySelector('.card-title').textContent = models[index].name;
    document.querySelector('.card-img-top').setAttribute('src',
        models[index].image);
}


