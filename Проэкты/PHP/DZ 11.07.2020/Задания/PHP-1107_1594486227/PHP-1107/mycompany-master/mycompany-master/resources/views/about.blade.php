@extends('layouts.app')

@section('title')
    About
@endsection

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4>About</h4>
                </div>

                <div class="card-body">
                    @if (session('status'))
                        <div class="alert alert-success" role="alert">
                            {{ session('status') }}
                        </div>
                    @endif

                    <h5>Контент страницы Про сайт ...</h5>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
