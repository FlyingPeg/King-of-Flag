<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\API\UserController;
use App\Http\Controllers\API\AuthController;
use App\Http\Controllers\API\RoomController;
use App\Http\Controllers\API\MoveController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::post('login', [AuthController::class, 'signin']);
Route::post('register', [AuthController::class, 'signup']);

Route::middleware('auth:sanctum')->group(function() {
    Route::resource('scores', UserController::class);
    Route::resource('rooms', RoomController::class);
    Route::resource('moves', MoveController::class);
    
    Route::get('/profile', [UserController::class, 'profile']);
    Route::put('/update-score', [UserController::class, 'score']);
    Route::post('/logout', [AuthController::class, 'signout']);
});

Route::fallback(function(){
    return response()->json([
        'success' => false,
        'message' => 'Page not found.',
    ], 404);
});
