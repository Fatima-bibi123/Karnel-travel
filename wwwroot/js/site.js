/* ==================== SITE.JS - CUSTOM JAVASCRIPT FOR KARNELTRAVELGUIDE.COM ==================== */

// Run when DOM is fully loaded
document.addEventListener('DOMContentLoaded', function () {

    // ==================== INITIALIZE AOS (ANIMATE ON SCROLL) ====================
    AOS.init({
        duration: 800,           // Animation duration in milliseconds
        once: true,              // Animation happens only once
        offset: 80,             // Trigger offset from bottom of viewport
        easing: 'ease-out-cubic' // Easing function
    });

    // ==================== NAVBAR SCROLL EFFECT ====================
    // Changes navbar from transparent to solid white when scrolling
    const navbar = document.getElementById('mainNav');
    window.addEventListener('scroll', function () {
        if (window.scrollY > 80) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
    });

    // ==================== BACK TO TOP BUTTON ====================
    const backToTopBtn = document.getElementById('backToTop');
    window.addEventListener('scroll', function () {
        if (window.scrollY > 400) {
            backToTopBtn.classList.add('show');
        } else {
            backToTopBtn.classList.remove('show');
        }
    });

    // Scroll to top when button is clicked
    backToTopBtn.addEventListener('click', function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });

    // ==================== COUNTER ANIMATION ====================
    // Animate numbers from 0 to target value when stats section comes into view
    const counters = document.querySelectorAll('.counter');
    let counterAnimated = false;

    // Function to animate a single counter
    function animateCounter(counter) {
        const target = parseInt(counter.getAttribute('data-target'));
        const duration = 2000;       // Animation duration in milliseconds
        const stepTime = 30;         // Update interval in milliseconds
        const steps = duration / stepTime;
        const increment = target / steps;
        let current = 0;

        const timer = setInterval(function () {
            current += increment;
            if (current >= target) {
                counter.textContent = target.toLocaleString();
                clearInterval(timer);
            } else {
                counter.textContent = Math.floor(current).toLocaleString();
            }
        }, stepTime);
    }

    // Intersection Observer to trigger counter animation when visible
    const statsSection = document.querySelector('.stats-section');
    if (statsSection) {
        const observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting && !counterAnimated) {
                    counterAnimated = true;
                    counters.forEach(function (counter) {
                        animateCounter(counter);
                    });
                }
            });
        }, { threshold: 0.3 });

        observer.observe(statsSection);
    }

    // ==================== HIGHLIGHT ACTIVE NAV LINK ====================
    // Get current page URL and highlight matching nav link
    const currentPath = window.location.pathname.toLowerCase();
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');

    navLinks.forEach(function (link) {
        const linkPath = link.getAttribute('href');
        if (linkPath && linkPath !== '/') {
            // Check if current path contains the link's action
            if (currentPath.includes(linkPath.toLowerCase())) {
                link.classList.add('active');
            }
        } else if (linkPath === '/' && (currentPath === '/' || currentPath === '')) {
            link.classList.add('active');
        }
    });

    // ==================== SMOOTH SCROLL FOR ANCHOR LINKS ====================
    document.querySelectorAll('a[href^="#"]').forEach(function (anchor) {
        anchor.addEventListener('click', function (e) {
            const targetId = this.getAttribute('href');
            if (targetId === '#') return;

            const targetElement = document.querySelector(targetId);
            if (targetElement) {
                e.preventDefault();
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
});
