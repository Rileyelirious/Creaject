extends Control

func _on_editor_text_changed() -> void:
	%MarkdownLabel.markdown_text = %EditorText.text
