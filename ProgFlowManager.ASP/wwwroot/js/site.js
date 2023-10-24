
/*===== DOM =====*/
document.addEventListener("DOMContentLoaded", function (event) {

    const toggle = document.querySelector('#header-toggle'),
        nav = document.querySelector('#nav-bar'),
        bodypd = document.querySelector('#body-pd'),
        headerpd = document.querySelector('#header'),
        logoname = document.querySelector('#logo-name'),
        navnames = document.querySelectorAll('#link-name'),
        menuState = sessionStorage.getItem('menuState'),
        footer = document.querySelector("footer")

    console.log(footer)

    function toggleMenuState() {
        // show navbar
        nav.classList.toggle('show')
        // change icon
        toggle.classList.toggle('bx-x')
        // add padding to body
        bodypd.classList.toggle('body-pd')
        // add padding to header
        headerpd.classList.toggle('body-pd')
        // display logo text
        logoname.classList.toggle('show-text')
        // display menu text
        navnames.forEach(n => n.classList.toggle('show-text'))

        // Store the menu state in sessionStorage
        sessionStorage.setItem('menuState', nav.classList.contains('show') ? 'open' : 'closed')
    }
    toggle.addEventListener('click', toggleMenuState);

    if (menuState === 'open') {
        toggleMenuState()
    }

    function isPageScrollable() {
        return bodypd.clientHeight >= window.innerHeight;
    }
    function updateFooterClass() {
        if (isPageScrollable()) {
            footer.classList.remove('fixed-footer')
        }
        else {
            footer.classList.add('fixed-footer')
        }
    }
    window.addEventListener('resize', updateFooterClass)
    window.addEventListener('load', updateFooterClass)



    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

    const controllerName = document.body.getAttribute('data-controller')
    sessionStorage.setItem('activeLink', controllerName)

    const activeLinkId = sessionStorage.getItem('activeLink');

    if (activeLinkId) {
        const currentActive = document.getElementById(activeLinkId)
        if (currentActive) {
            currentActive.classList.add('active')
        }
    }

    // Your code to run since DOM is loaded and ready
});