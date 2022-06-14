<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Http\Controllers\API\BaseController as BaseController;
use App\Http\Resources\Move as MoveResource;
use App\Models\Move;
use Validator;
use Auth;
use DB;

class MoveController extends BaseController
{
    public function index()
    {   
        try{
            $move = Move::all();
            return $this->sendResponse(MoveResource::collection($move), 'Moves fetched.');
        }catch(\Exception $e){
            return $this->sendError('Error.');
        } 
    }

    public function show($room_id)
    {        
        $move = Move::where('room_id', $room_id)->first();
        if (is_null($move)) {
            return $this->sendError('Room does not exist.');
        }
        return $this->sendResponse(new MoveResource($move), 'Move fetched.');
    }
}
