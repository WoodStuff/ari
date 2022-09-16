const canvas = document.querySelector('canvas');
const ctx = canvas.getContext('2d');

const cx = canvas.width = window.innerWidth;
const cy = canvas.height = window.innerHeight;

/**
 * Draw a frame to the canvas.
 */
function draw() {
	ctx.clearRect(0, 0, cx, cy);
	ctx.fillRect(0, 0, cx, cy);
	requestAnimationFrame(draw);
}