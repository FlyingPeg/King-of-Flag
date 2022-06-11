<?php
   
namespace App\Http\Controllers\API;
   
use Illuminate\Http\Request;
use App\Http\Controllers\API\BaseController as BaseController;
use Illuminate\Support\Facades\Auth;
use Validator;
use App\Models\User;
use App\Http\Resources\User as UserResource;
   
class AuthController extends BaseController
{
    public function signin(Request $request)
    {
        if(Auth::attempt([
            'email' => $request->email, 
            'password' => $request->password,
            ])){ 
                $authUser = Auth::user(); 
                $success['token'] =  $authUser->createToken('TRtescsx34WM2s6xn7fXGEaE73nbxkmAXWpZ9EQ55MfnbxyVsmUBnbkvAZg5zBEcdWh4WDk96Apg9whftY4g4UgSxNQqYUKaHjG664sgtKhuZVV3zNRqbh2fbJYf')->plainTextToken; 
                $success['name'] = $authUser->name;
                $success['email'] = $authUser->email;
                $success['score'] = $authUser->score;
    
                return $this->sendResponse($success, 'User signed in');
            } 
            else{ 
                return $this->sendError('Unauthorised.', ['error'=>'Unauthorised']);
            } 
    }

    public function signup(Request $request)
    {
        try{
            $validator = Validator::make($request->all(), [
                'name' => 'required',
                'email' => 'required|email',
                'password' => 'required',
                'confirm_password' => 'required|same:password',
            ]);
    
            if($validator->fails()){
                return $this->sendError('Error validation', $validator->errors());       
            }
    
            $authUser = User::create([
                'name' => $request->name,
                'email' => $request->email,
                'score' => 0,
                'password' => bcrypt($request->password),
            ]);
            $success['token'] =  $authUser->createToken('TRtescsx34WM2s6xn7fXGEaE73nbxkmAXWpZ9EQ55MfnbxyVsmUBnbkvAZg5zBEcdWh4WDk96Apg9whftY4g4UgSxNQqYUKaHjG664sgtKhuZVV3zNRqbh2fbJYf')->plainTextToken;
            $success['name'] =  $authUser->name;
            $success['email'] =  $authUser->email;
            $success['score'] =  $authUser->score;
    
            return $this->sendResponse($success, 'User created successfully.');
        }catch(\Exception $e){
            return $this->sendError('Email existed.');       
        }
    }

    public function signout(Request $request)
    {
        try{
            // Revoke all tokens...
            $authUser = Auth::user(); 
            $success['id'] = $authUser->id;
            $success['name'] =  $authUser->name;
            $authUser->tokens()->delete();
            return $this->sendResponse($success, 'User signed out.');
        }catch(\Exception $e){
            return $this->sendError('Signout error');
        }
    }      
   
}