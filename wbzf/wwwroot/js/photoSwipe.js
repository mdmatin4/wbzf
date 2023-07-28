import PhotoSwipeLightbox from './photoswipe-lightbox.esm.min.js';

const lightbox = new PhotoSwipeLightbox({
    // may select multiple "galleries"
    gallery: '.gallery-psw',

    // Elements within gallery (slides)
    children: 'a',
    showHideAnimationType: 'zoom',
    // setup PhotoSwipe Core dynamic import
    pswpModule: () => import('./photoswipe.esm.min.js')
});
lightbox.init();