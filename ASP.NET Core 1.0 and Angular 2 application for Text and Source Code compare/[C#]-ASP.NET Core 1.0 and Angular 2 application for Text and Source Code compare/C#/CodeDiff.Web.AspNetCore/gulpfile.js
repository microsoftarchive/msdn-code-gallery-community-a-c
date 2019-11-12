/// <binding BeforeBuild='default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

var _ = require('lodash'),
    gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename');

//var angularJs = [
//    './node_modules/angular2/bundles/angular2.dev.js',
//    './node_modules/angular2/bundles/router.dev.js',
//    './node_modules/angular2/bundles/angular2-polyfills.js',
//    './node_modules/angular2/bundles/http.dev.js'
//];

var js = [
    './node_modules/bootstrap/dist/js/bootstrap.js',
    './node_modules/es6-shim/es6-shim.js',
    './node_modules/zone.js/dist/zone.js',
    './node_modules/reflect-metadata/Reflect.js',
    './node_modules/systemjs/dist/system.src.js',
    './node_modules/jquery/dist/jquery.js'
];

var css = [
    './node_modules/bootstrap/dist/css/bootstrap.css'
];

var fonts = [
    './node_modules/bootstrap/dist/fonts/*.*'
];

gulp.task('copy-js', function () {
    _.forEach(js, function (file, _) {
        gulp.src(file)
            .pipe(gulp.dest('./wwwroot/js'))
    });
    //_.forEach(angularJs, function (file, _) {
    //    gulp.src(file)
    //        .pipe(gulp.dest('./wwwroot/js/angular2'))
    //});
});

gulp.task('copy-min-js', function () {
    _.forEach(js, function (file, _) {
        gulp.src(file)
            .pipe(uglify())
            .pipe(rename({ extname: '.min.js' }))
            .pipe(gulp.dest('./wwwroot/js'))
    });
    //_.forEach(angularJs, function (file, _) {
    //    gulp.src(file)
    //        .pipe(uglify())
    //        .pipe(rename({ extname: '.min.js' }))
    //        .pipe(gulp.dest('./wwwroot/js/angular2'))
    //});
});

gulp.task('copy-css', function () {
    _.forEach(css, function (file, _) {
        gulp.src(file)
            .pipe(gulp.dest('./wwwroot/css'))
    });
    _.forEach(fonts, function (file, _) {
        gulp.src(file)
            .pipe(gulp.dest('./wwwroot/fonts'))
    });
});

gulp.task('copy-min-css', function () {
    _.forEach(css, function (file, _) {
        gulp.src(file)
            .pipe(cssmin())
            .pipe(rename({ extname: '.min.css' }))
            .pipe(gulp.dest('./wwwroot/css'))
    });
    _.forEach(fonts, function (file, _) {
        gulp.src(file)
            .pipe(gulp.dest('./wwwroot/fonts'))
    });
});

gulp.task('default', ['copy-js', 'copy-css']);
gulp.task('minify', ['copy-min-js', 'copy-min-css']);